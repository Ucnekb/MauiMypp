namespace MauiMypp;

public partial class Ayalar : ContentPage
{
    public Ayalar()
    {
        InitializeComponent();
    }



    private void DarkModeOnOff(object sender, ToggledEventArgs e)
    {
        if (e.Value)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;
    }
}
