using System;
using TechTalk.SpecFlow;
using RestSharp;
using System.Text.Json;
using NUnit.Framework;
using System.Configuration;
using REstSharpDemo.Settings;
using REstSharpDemo.Utilities;

namespace REstSharpDemo.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        private SettingObj _obj;
        public StepDefinitions(SettingObj settings) { 
            this._obj = settings;
        }
        //Remember when using a data coming from appSetting.config file
        //We must change to static the property/variable/object we are using
        //within a Gerkin Keyword used by specflow to use it
        static string baseURl = ConfigurationManager.AppSettings["baseUrl"];
        static RestClient client = new RestClient(baseURl);

        [Given(@"I perform GET operation for ""([^""]*)""")]
        public void GivenIPerformGETOperationFor(string endpoint)
        {
            _obj.request = new RestRequest(endpoint, Method.GET);
        }

        [When(@"I perform operation for post ""([^""]*)""")]
        public void WhenIPerformOperationForPost(string postNumber)
        {
            _obj.request.AddUrlSegment("Id", Convert.ToInt32(postNumber));
        }

        [Then(@"I should see the expected authorname as ""([^""]*)""")]
        public void ThenIShouldSeeTheNameAs(string expectedAuthorValue)
        {
            var response = _obj.client.Execute(_obj.request);
            var author = response.deserializeResponse()["author"];
            Assert.That(author, Is.EqualTo(expectedAuthorValue), "Author is not correct");
        }
    }
}
