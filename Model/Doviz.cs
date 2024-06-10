using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMypp.Model
{
    public class Doviz
    {
        public static async Task<string> GetAltinDovizGuncelKurlar()
        {
            HttpClient client = new HttpClient();
            string url = "https://finans.truncgil.com/today.json";
            using HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string jsondata = await response.Content.ReadAsStringAsync();
            return jsondata;
        }
    }
}
