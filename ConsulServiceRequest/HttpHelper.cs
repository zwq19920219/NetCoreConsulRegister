using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Runtime;
using System.Threading.Tasks;

namespace ConsulServiceRequest
{
    public static class HttpHelper
    {
        /// <summary>
        /// 同步Get请求
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="url">URL.</param>
        /// <param name="headers">Headers.</param>
        /// <param name="tiemout">Tiemout.</param>
        public static string HttpGet(string url, Dictionary<string, string> headers = null,int tiemout=0)
        {
            using (HttpClient client = new HttpClient())
            {
                if(headers!=null)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);

                    }
                }
                if(tiemout>0)
                {
                    client.Timeout = new TimeSpan(0, 0, tiemout);
                }

                byte[] resulbytes = client.GetByteArrayAsync(url).Result;
                return Encoding.Default.GetString(resulbytes);
            }

        }

        /// <summary>
        /// 异步Get请求
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="url">URL.</param>
        /// <param name="headers">Headers.</param>
        /// <param name="tiemout">Tiemout.</param>
        public static async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers = null, int tiemout = 0)
        {
            using (HttpClient client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);

                    }
                }
                if (tiemout > 0)
                {
                    client.Timeout = new TimeSpan(0, 0, tiemout);
                }

                byte[] resulbytes = await client.GetByteArrayAsync(url);
                return Encoding.Default.GetString(resulbytes);
            }

        }

    }
}
