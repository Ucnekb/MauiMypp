using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace MauiMypp
{
    public partial class EditTaskPage : ContentPage
    {
        FirebaseClient firebase;
        Yapýlacaklar parentPage;
        TodoItem currentItem;

        public EditTaskPage(Yapýlacaklar parentPage, TodoItem item)
        {
            InitializeComponent();
            firebase = new FirebaseClient("https://mauimyapp1-b924a-default-rtdb.firebaseio.com/");
            this.parentPage = parentPage;
            this.currentItem = item;

            // Pre-populate fields with current task details
            EntryTitle.Text = item.Task;
            EditorDetails.Text = item.Details;
            DatePicker.Date = DateTime.Parse(item.Date);
            TimePicker.Time = TimeSpan.Parse(item.Time);
        }

        async void SaveTaskButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EntryTitle.Text) && DatePicker.Date != null && TimePicker.Time != null)
            {
                currentItem.Task = EntryTitle.Text;
                currentItem.Details = EditorDetails.Text;
                currentItem.Date = DatePicker.Date.ToString("d");
                currentItem.Time = TimePicker.Time.ToString(@"hh\:mm");

                await firebase.Child("TodoItems").Child(currentItem.Key).PutAsync(currentItem);
                await parentPage.LoadItems(); // Ensure parent page loads items after editing the task
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
            }
        }
    }
}
