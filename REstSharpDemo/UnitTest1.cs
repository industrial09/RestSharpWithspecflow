using RestSharp;
using System;
using System.Text.Json;
using NUnit.Framework;
using RestSharp.Deserializers;
using System.Collections.Generic;
using REstSharpDemo.Utilities;

namespace REstSharpDemo
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void validateGetData()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{requestId}", Method.GET);
            request.AddUrlSegment("requestId", 1);
            var response = client.ExecuteAsyncRequest<Data>(request).GetAwaiter().GetResult();
            //1st way to Deserialize response coming from a request
            //Go into deserializeResponse method
            //var response = client.Execute(request);
            //var author = response.deserializeResponse()["author"];
            Assert.That(response.Data.author, Is.EqualTo("Karthik KK"), "Author is not correct");
        }

        [Test]
        public void validatePostData() {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/", Method.POST);
            var responseObj = new RestResponse();   
            request.RequestFormat = DataFormat.Json; //Parameter to be passed needs to be parsed with the format of the body
            request.AddBody(new Data() { Id = 32, Title = "Automation", author = "Mario"}); //Parameter passed is an Object
            //2nd way to Deserialize response coming from a request
            var response = client.Execute<Data>(request);
            Assert.That(response.Data.author, Is.EqualTo("Mario"), "Name object is not the one created");
        }
    }
}
