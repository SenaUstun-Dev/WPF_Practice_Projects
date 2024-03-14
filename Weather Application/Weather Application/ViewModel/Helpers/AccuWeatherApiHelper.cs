using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Documents;
using Weather_Application.Model;

namespace Weather_Application.ViewModel.Helpers
{
    public class AccuWeatherApiHelper
    {   
        /*heplers biryerlere gerekli bağlantıları sağlamaya ve veriyi çekmeye yardım eder.
        VMs bu bağlantı kullanılarak gene helper'ın aldığı verileri alır. 
        (helper bağlantıyı kurup veriyi alıp VM'e gönderir)
        DB bağlanmak veya internet tabanlı api bağlantıları vb. için kullanılır*/

        //---konum bilgisini alabilmek için api'nin sitesine temel bağlantı elemanlarını yazıyoruz---

        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string API_KEY = "p6v52rwwi93MYUZs0vyvlwkov6FbiomG";
        //location:
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        //Hava durumu bilgileri:
        public const string CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";

        
        
        //-- ^^ api bağlantı ^^--

        //-- vv veri çeken ve gönderen kodlar vv--

        /*  apilerden veri çeken-döndüren metodlar "async" olarak yazılır.
         Async method, o metodun içersinde "await" olarak işaretlenmiş kodların 
        sonraki koda geçilmeden önce çalıştığına emin olur.
            Yani await edilen kod satırının işini bitirmesini bekler. Normalde de kodlar 
        ???zaten yukardan aşağı sırayla çalışsada api olunca bazen birinin işi bitmeden öbürüne geçebiliyor???
        Async gerekli bir tedbir*/

        public static async Task<List<City>> GetLocations(string query)
        {
            List<City> locations = new List<City>();

            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT,API_KEY, query);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                locations = JsonConvert.DeserializeObject<List<City>>(json);  //using Newtonsoft.Json; paket lazım
            }

            return locations;
        }

        public static async Task<Conditions> GetConditions(string key)
        {
            Conditions conditions = new Conditions();

            string url = BASE_URL + string.Format(CONDITIONS_ENDPOINT,key, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                conditions = (JsonConvert.DeserializeObject<List<Conditions>>(json)).FirstOrDefault();
            }

            return conditions;
        }


    }
}
