using MauiMypp.Model;

namespace MauiMypp;

public partial class NewsDetailPage : ContentPage
{
    private Item _haber;  // Haber bilgisini tutacak deðiþken

    public NewsDetailPage(Item haber)
    {
        InitializeComponent();
        _haber = haber;
        webView.Source = haber.link;
    }

    private async void ShareNews_Clicked(object sender, EventArgs e)
    {
        await ShareUri(_haber.link, Share.Default);
    }

    public async Task ShareUri(string uri, IShare share)
    {
        await share.RequestAsync(new ShareTextRequest
        {
            Uri = uri,
            Title = _haber.title
        });
    }
}
