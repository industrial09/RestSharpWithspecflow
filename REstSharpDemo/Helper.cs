using Newtonsoft.Json;
using RestSharp;
using System.IO;

namespace REstSharpDemo
{
    public class Helper
    {
        private RestClient client;
        private RestRequest request;

        public RestClient setUrl(string baseUrl, string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            client = new RestClient(url);
            return client;
        }

        public RestRequest createGetRequest()
        {
            request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            //request.AddFile("Test file", @"C:\Users\yadavm\Downloads\Test.txt", "multipart/form-data");
            return request;
        }

        public RestRequest createPostRequest<T>(T payload) where T : class
        {
            request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddParameter("application/json", payload, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(payload);
            return request;
        }

        public RestRequest createPutRequest<T>(T payload) where T : class
        {
            request = new RestRequest(Method.PUT);
            request.AddHeader("Accept", "application/json");
            //request.AddParameter("application/json", payload, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(payload);
            return request;
        }

        public RestRequest createDeleteRequest()
        {
            request = new RestRequest()
            {
                Method = Method.DELETE
            };
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public IRestResponse getResponse(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }
    }
}
