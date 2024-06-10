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
        string sehir = await DisplayPromptAsync("�ehir:", "�ehir ismi", "OK", "Cancel");
        if (!string.IsNullOrEmpty(sehir))
        {
            sehir = sehir.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
            sehir = sehir.Replace('�', 'C');
            sehir = sehir.Replace('�', 'G');
            sehir = sehir.Replace('�', 'I');
            sehir = sehir.Replace('�', 'O');
            sehir = sehir.Replace('�', 'U');
            sehir = sehir.Replace('�', 'S');
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
