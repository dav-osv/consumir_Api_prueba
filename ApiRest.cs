using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace ProyectoReloj
{


    public class ApiRest
    {

        private const string username = "admin";
        private const string password = "reloj4891";
        private const string endpoint = "http://192.168.100.6";

        public async Task<JObject> obtenerRegistrosEmpleados()
        {
            try
            {
                Uri uri = new Uri(endpoint+"/ISAPI/AccessControl/AcsEvent?format=json");
                Console.WriteLine("url: " + uri.ToString());
                var credentialCache = new CredentialCache();
                credentialCache.Add(uri, "Digest", new NetworkCredential(username, password));

                var handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    Credentials = credentialCache
                };

                using (var HttClient = new HttpClient())
                {
                    var httpClient = new HttpClient(handler);
                    var myObject = new
                    {
                        searchID = "0",
                        searchResultPosition = 0,
                        maxResults = 1000,
                        major = 5,
                        minor = 0,
                        startTime = "2023-01-01T00:00:00-00:00",
                        endTime = "2023-01-07T00:00:00-00:00"
                    };

                    var myEvent = new
                    {
                        AcsEventCond = myObject
                    };

                    var httpContent = new StringContent(JsonConvert.SerializeObject(myEvent), Encoding.UTF8, "application/json");
                    var httpResponse = await httpClient.PostAsync(uri, httpContent);

                    if (httpResponse.IsSuccessStatusCode) {
                        var responseContent = await httpResponse.Content.ReadAsStringAsync();
                        return JObject.Parse(responseContent);

                    }

                    Console.WriteLine("Hubo un error en la peticion codigo [" + httpResponse.IsSuccessStatusCode + "]" );
                    return JObject.Parse("{success: False, mensaje: Hubo un error en la peticion codigo [\" + httpResponse.IsSuccessStatusCode + \"]\"  }");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return JObject.Parse("{success:False, mensaje:"+ e.Message+"}");
            }
        }
    }
}
