using Newtonsoft.Json;
using System.Text;

namespace DevNcore.RestApi
{
    public class RestService
    {
        private HttpClient httpClient;
        public RestDataPack Request;
        public RestDataPack Response;

        public RestService()
        {
            Request = new();
            Response = new();
        }

        public async Task<RestDataPack> RunAsync(string url, string method, object data)
        {
            await Task.Delay(100);
            try
            {
                string jsonObject = JsonConvert.SerializeObject(data);
                StringContent content = new(jsonObject, Encoding.UTF8, "application/json");

                httpClient = new();
                HttpResponseMessage result = await httpClient.PostAsync($"{url}/{method}", content);

                if (result.Content != null)
                {
                    Response.Data = result.Content.ReadAsStringAsync().Result;
                    return Response;
                }
                else
                    Request.IsContent = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Exception");
                Request.IsError = true;
                Request.Exception = ex;
            }
            return Request;
        }

        public RestDataPack Run(string url, string method, object data)
        {
            try
            {
                string jsonObject = JsonConvert.SerializeObject(data);
                StringContent content = new(jsonObject, Encoding.UTF8, "application/json");

                httpClient = new();
                HttpResponseMessage result = httpClient.PostAsync($"{url}/{method}", content).Result;

                if (result.Content != null)
                {
                    Response.Data = result.Content.ReadAsStringAsync().Result;
                    return Response;
                }
                else
                    Request.IsContent = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Exception");
                Request.IsError = true;
                Request.Exception = ex;
            }
            return Request;
        }
    }
}