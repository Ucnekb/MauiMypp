using MauiMypp.Model;
using System.Collections.ObjectModel;

namespace MauiMypp;

public partial class HavaDurumu : ContentPage
{
    public ObservableCollection<SehirHavaDurumu> Sehirler { get; set; }
    public HavaDurumu()
	{
        InitializeComponent();
        Sehirler = new ObservableCollection<SehirHavaDurumu>();
        BindingContext = this;
    }

    private async void AddCity_Clicked(object sender, EventArgs e)
    {
        string sehir = await DisplayPromptAsync("Þehir:", "Þehir ismi", "OK", "Cancel");
        if (!string.IsNullOrEmpty(sehir))
        {
            sehir = sehir.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
            sehir = sehir.Replace('Ç', 'C');
            sehir = sehir.Replace('Ð', 'G');
            sehir = sehir.Replace('Ý', 'I');
            sehir = sehir.Replace('Ö', 'O');
            sehir = sehir.Replace('Ü', 'U');
            sehir = sehir.Replace('Þ', 'S');
            Sehirler.Add(new SehirHavaDurumu() { Name = sehir });
        }
    }

    private async void RemoveCity_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var sehir = button.BindingContext as SehirHavaDurumu;
        Sehirler.Remove(sehir);
    }
}
