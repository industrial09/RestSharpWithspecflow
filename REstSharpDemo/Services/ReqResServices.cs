using Newtonsoft.Json;
using RestSharp;
using REstSharpDemo.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REstSharpDemo.Services
{
    public class ReqResServices
    {
        Helper _helper;

        public ReqResServices(Helper helper) => _helper = helper;

        public IRestResponse GetUserList(string baseUrl, string endpoint) {
            var client = _helper.setUrl(baseUrl, endpoint);
            var request = _helper.createGetRequest();
            var response = _helper.getResponse(client, request);
            return response;
            //UserList content = _helper.getContent<UserList>(response);
        }

        public IRestResponse createUser(string baseUrl, string endpoint, dynamic payload)
        {
            var client = _helper.setUrl(baseUrl, endpoint);
            var request = _helper.createPostRequest(payload);
            var response = _helper.getResponse(client, request);
            return response;
        }

        public IRestResponse updateUser(string baseUrl, string endpoint, dynamic payload)
        {
            var client = _helper.setUrl(baseUrl, endpoint);
            var request = _helper.createPutRequest(payload);
            var response = _helper.getResponse(client, request);
            return response;
        }

        public Mappings getContent<Mappings>(IRestResponse response)
        {
            var content = response.Content;
            var res = JsonConvert.DeserializeObject<Mappings>(content);
            return res;
        }
    }
}
