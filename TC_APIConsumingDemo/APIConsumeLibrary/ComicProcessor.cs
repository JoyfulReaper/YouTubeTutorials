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
    public static class ComicProcessor
    {
        public static async Task<ComicModel> LoadComic(int comicNumber = 0)
        {
            string url = "";

            if(comicNumber > 0)
            {
                url = $"https://xkcd.com/{comicNumber}/info.0.json";
            }
            else
            {
                url = "https://xkcd.com/info.0.json";
            }

            return await ApiHelper.GetAsync<ComicModel>(url, TimeSpan.FromDays(1));



            // After messing around a bit decided not to use this code:
            // MonkeyCaches HttpCache create a new HttpClient for each requst which you shouldn't do
            //try
            //{
            //    var result = await HttpCache.Current.GetCachedAsync(Barrel.Current, url, TimeSpan.FromSeconds(30), TimeSpan.FromDays(1));
            //    return JsonConvert.DeserializeObject<ComicModel>(result);
            //} 
            //catch (HttpCacheRequestException ex)
            //{
            //    throw ex;
            //}

            // This is the code from the Tim Corey YT video
            //using HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
            //if (response.IsSuccessStatusCode)
            //{
            //    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();

            //    return comic;
            //}
            //else
            //{
            //    throw new Exception(response.ReasonPhrase);
            //}

        }
    }
}
