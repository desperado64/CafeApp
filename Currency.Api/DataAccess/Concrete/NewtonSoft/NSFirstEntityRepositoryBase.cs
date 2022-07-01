using Currency.Api.DataAccess.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Api.DataAccess.Concrete.NewtonSoft
{
    public class NSFirstEntityRepositoryBase<V> : IFirstEntityRepository<V> where V : class
    {
        public V Get(string url)
        {
            V response = null;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(url);
                    response = JsonConvert.DeserializeObject<V>(json);
                    return response;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return response;
            }
        }

        public List<V> GetList(string url)
        {
            List<V> response = null;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(url);
                    response = JsonConvert.DeserializeObject<List<V>>(json);
                    return response;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return response;
            }
        }

        public V Get(string username, string password, string url)
        {
            V response = null;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                               .GetBytes(username + ":" + password));

                    wc.Headers.Add("Authorization", "Basic " + encoded);
                    var json = wc.DownloadString(url);
                    response = JsonConvert.DeserializeObject<V>(json);
                    return response;
                }
            }
            catch (Exception)
            {
                return response;
            }
        }


    }
}
