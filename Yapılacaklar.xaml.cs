namespace MauiMypp;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

public partial class Yapılacaklar : ContentPage
{
    FirebaseClient firebase;

    public ObservableCollection<TodoItem> Items { get; set; }

    public Yapılacaklar()
    {
        InitializeComponent();
        firebase = new FirebaseClient("https://mauimyapp1-b924a-default-rtdb.firebaseio.com/");

        Items = new ObservableCollection<TodoItem>();

        ToDoListView.ItemsSource = Items;

        LoadItems();
    }

    public async Task LoadItems()
    {
        var items = await firebase.Child("TodoItems").OnceAsync<TodoItem>();
        Items.Clear();
        foreach (var item in items)
        {
            Items.Add(new TodoItem
            {
                Key = item.Key,
                Task = item.Object.Task,
                Details = item.Object.Details,
                Date = item.Object.Date,
                Time = item.Object.Time
            });
        }
    }

    async void AddButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTaskPage(this));
    }

    async void EditButton_Clicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var item = (TodoItem)button.BindingContext;
        await Navigation.PushAsync(new EditTaskPage(this, item));
    }

    async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var item = (TodoItem)button.BindingContext;
        var confirm = await DisplayAlert("Silinsin mi?", $"{item.Task} görevi silincek ?", "Yes", "No");
        if (confirm)
        {
            await firebase.Child("TodoItems").Child(item.Key).DeleteAsync();
            await LoadItems();
        }
    }
}

public class TodoItem
{
    public string Key { get; set; }
    public string Task { get; set; }
    public string Details { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
}
