using MonkeyCache;
using MonkeyCache.SQLite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIConsumeLibrary
{
    public static class SunProcessor
    {
        public static async Task<SunModel> LoadSunInformation(int comicNumber = 0)
        {
            string url = "https://api.sunrise-sunset.org/json?lat=40.2631482&lng=-76.8828616&date=today";

            return (await ApiHelper.GetAsync<SunResultModel>(url, TimeSpan.FromHours(12))).Results;

            // Not sure why, but MonkeyCache doesnt cache the response using this:
            //try
            //{
            //    var result = await HttpCache.Current.GetCachedAsync(Barrel.Current, url, TimeSpan.FromSeconds(30), TimeSpan.FromHours(12));
            //    return JsonConvert.DeserializeObject<SunResultModel>(result).Results;
            //}
            //catch (HttpCacheRequestException ex)
            //{
            //    throw ex;
            //}
        }
    }
}
