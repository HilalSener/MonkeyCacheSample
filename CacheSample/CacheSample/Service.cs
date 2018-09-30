using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CacheSample.Model;
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace CacheSample
{
    public class Service
    {
        public async Task<CurrencyModel> GetCurrencyAsync()
        {
            var url = "https://lookup.binlist.net/45717360";
            var client = new HttpClient();

            if (!CrossConnectivity.Current.IsConnected && !Barrel.Current.IsExpired(key: url))
                return Barrel.Current.Get<CurrencyModel>(key: url);

            CurrencyModel result = null;

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<CurrencyModel>(response.Content.ReadAsStringAsync().Result);

                Barrel.Current.Add(key: url, data: result, expireIn: TimeSpan.FromDays(1));
            }

            return result;
        }
    }
}