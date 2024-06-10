using MauiMypp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using static MauiMypp.Model.Doviz;

namespace MauiMypp;

public partial class Döviz : ContentPage
{
    public Döviz()
    {
        InitializeComponent();
        LoadData();
    }

    internal void ChangeBackgroundColor(Color yellow)
    {
        throw new NotImplementedException();
    }

    private async void LoadData()
    {
        try
        {
            string jsonData = await Doviz.GetAltinDovizGuncelKurlar();
            JObject data = JObject.Parse(jsonData);

            decimal dolarAlis = ParseDecimal(data["USD"]["Alış"].ToString());
            decimal dolarSatis = ParseDecimal(data["USD"]["Satış"].ToString());
            decimal dolarFark = dolarSatis - dolarAlis;

            decimal euroAlis = ParseDecimal(data["EUR"]["Alış"].ToString());
            decimal euroSatis = ParseDecimal(data["EUR"]["Satış"].ToString());
            decimal euroFark = euroSatis - euroAlis;

            decimal SterlinAlis = ParseDecimal(data["GBP"]["Alış"].ToString());
            decimal SterlinSatis = ParseDecimal(data["GBP"]["Satış"].ToString());
            decimal SterlinFark = SterlinSatis - SterlinAlis;

            decimal GümüşAlis = ParseDecimal(data["gumus"]["Alış"].ToString());
            decimal GümüşSatis = ParseDecimal(data["gumus"]["Satış"].ToString());
            decimal GümüşFark = GümüşSatis - GümüşAlis;

            decimal RubleAlis = ParseDecimal(data["RUB"]["Alış"].ToString());
            decimal RubleSatis = ParseDecimal(data["RUB"]["Satış"].ToString());
            decimal RubleFark = RubleSatis - RubleAlis;

            decimal OnsAlis = ParseDecimal(data["ons"]["Alış"].ToString());
            decimal OnsSatis = ParseDecimal(data["ons"]["Satış"].ToString());
            decimal OnsFark = OnsSatis - OnsAlis;

 

            decimal YarımAAlis = ParseDecimal(data["yarim-altin"]["Alış"].ToString());
              decimal YarımASatis = ParseDecimal(data["yarim-altin"]["Satış"].ToString()) ;
             decimal YarımAFark = YarımASatis - YarımAAlis;


            decimal gramAlis = ParseDecimal(data["gram-altin"]["Alış"].ToString());
            decimal gramSatis = ParseDecimal(data["gram-altin"]["Satış"].ToString());
            decimal gramFark = gramSatis - gramAlis;



            gramAlisLabel.Text = gramAlis.ToString("N4", CultureInfo.InvariantCulture);
            gramSatisLabel.Text = gramSatis.ToString("N4", CultureInfo.InvariantCulture);
            gramFarkLabel.Text = gramFark.ToString("N4", CultureInfo.InvariantCulture);


            DolarAlisLabel.Text = dolarAlis.ToString("N4", CultureInfo.InvariantCulture);
            DolarSatisLabel.Text = dolarSatis.ToString("N4", CultureInfo.InvariantCulture);
            DolarFarkLabel.Text = dolarFark.ToString("N4", CultureInfo.InvariantCulture);

            EuroAlisLabel.Text = euroAlis.ToString("N4", CultureInfo.InvariantCulture);
            EuroSatisLabel.Text = euroSatis.ToString("N4", CultureInfo.InvariantCulture);
            EuroFarkLabel.Text = euroFark.ToString("N4", CultureInfo.InvariantCulture);

            SterlinAlisLabel.Text = SterlinAlis.ToString("N4", CultureInfo.InvariantCulture);
            SterlinSatisLabel.Text = SterlinSatis.ToString("N4", CultureInfo.InvariantCulture);
            SterlinFarkLabel.Text = SterlinFark.ToString("N4", CultureInfo.InvariantCulture);

            GümüşAlisLabel.Text = GümüşAlis.ToString("N4", CultureInfo.InvariantCulture);
            GümüşSatisLabel.Text = GümüşSatis.ToString("N4", CultureInfo.InvariantCulture);
            GümüşFarkLabel.Text = GümüşFark.ToString("N4", CultureInfo.InvariantCulture);

            OnsAlisLabel.Text = OnsAlis.ToString("N4", CultureInfo.InvariantCulture);
            OnsSatisLabel.Text = OnsSatis.ToString("N4", CultureInfo.InvariantCulture);
            OnsFarkLabel.Text = OnsFark.ToString("N4", CultureInfo.InvariantCulture);

            RubAlisLabel.Text = RubleAlis.ToString("N4", CultureInfo.InvariantCulture);
            RubSatisLabel.Text = RubleSatis.ToString("N4", CultureInfo.InvariantCulture);
            RubFarkLabel.Text = RubleFark.ToString("N4", CultureInfo.InvariantCulture);


            yarimaltinAlisLabel.Text = YarımAAlis.ToString("N4", CultureInfo.InvariantCulture);
               yarimaltinSatisLabel.Text = YarımASatis.ToString("N4", CultureInfo.InvariantCulture);
              yarimaltinFarkLabel.Text = YarımAFark.ToString("N4", CultureInfo.InvariantCulture);

        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", ex.Message, "OK");
        }
    }

    private decimal ParseDecimal(string input)
    {
        // Remove currency symbol and replace thousand and decimal separators
        string cleanedInput = input.Replace("$", "").Replace(".", "").Replace(",", ".");
        return Convert.ToDecimal(cleanedInput, CultureInfo.InvariantCulture);
    }

}













