using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace MauiMypp
{
    public partial class AddTaskPage : ContentPage
    {
        FirebaseClient firebase;
        Yapýlacaklar parentPage;

        public AddTaskPage(Yapýlacaklar parentPage)
        {
            InitializeComponent();
            firebase = new FirebaseClient("https://mauimyapp1-b924a-default-rtdb.firebaseio.com/");
            this.parentPage = parentPage;
        }

        async void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EntryTitle.Text) && DatePicker.Date != null && TimePicker.Time != null)
            {
                var newItem = new TodoItem
                {
                    Task = EntryTitle.Text,
                    Details = EditorDetails.Text,
                    Date = DatePicker.Date.ToString("d"),
                    Time = TimePicker.Time.ToString(@"hh\:mm")
                };
                await firebase.Child("TodoItems").PostAsync(newItem);
                await parentPage.LoadItems(); 
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
            }
        }
    }
}
