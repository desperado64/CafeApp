using Currency.Api.DataAccess.Abstract;
using Currency.Api.Entities.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Api.DataAccess.Concrete.NewtonSoft
{
    public class NSSecondEntityRepositoryBase<TEntity, V> : ISecondEntityRepository<TEntity, V>
         where TEntity : class, IEntity, new()
         where V : class
    {
        public V Post(string url, TEntity request)
        {
            V Response = null;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);
                    streamWriter.Write(json);
                }


                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Response = JsonConvert.DeserializeObject<V>(result);
                }

                return Response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Response;
            }
        }

        public List<V> PostV2(string url, TEntity request)
        {
            List<V> Response = null;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);
                    streamWriter.Write(json);
                }


                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Response = JsonConvert.DeserializeObject<List<V>>(result);
                }

                return Response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Response;
            }
        }

        public V Post(string username, string password, string url, TEntity request)
        {
            V Response = null;
            try
            {
                string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                               .GetBytes(username + ":" + password));


                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);
                    streamWriter.Write(json);
                }


                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Response = JsonConvert.DeserializeObject<V>(result);
                }

                return Response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Response;
            }
        }


    }
}
