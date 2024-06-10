namespace MauiMypp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void KayitLoginEkranıGoster(object sender, EventArgs e)
        {
            if (kayitEkran.IsVisible)
            {
                kayitEkran.IsVisible = false;
                loginEkran.IsVisible = true;
            }
            else
            {
                kayitEkran.IsVisible = true;
                loginEkran.IsVisible = false;
            }
        }

        private async void RegisterClicked(object sender, EventArgs e)
        {
            var user = await Model.FireBaseServices.Register(txtName.Text, txtREmail.Text, txtRPassword.Text);

            if (user != null)
            {
                await DisplayAlert("Başarılı", "Kayıt başarılı", "Tamam");
            }
            else
            {
                await DisplayAlert("Hata", "Kayıt başarısız", "Tamam");
            }
        }

        private async void LoginClicked(object sender, EventArgs e)
        {
            var user = await Model.FireBaseServices.Login(txtEmail.Text, txtPassword.Text);

            if (user != null)
            {
                await DisplayAlert("Hoşgeldiniz", "Giriş başarılı", "Tamam");

                Navigation.PushAsync(new I() {});

            }
            else
            {
                await DisplayAlert("Hata", "Kullanıcı adı veya şifre hatalı", "Tamam");
            }
        }
    }
}
