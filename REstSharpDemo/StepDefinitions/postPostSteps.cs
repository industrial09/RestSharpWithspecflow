using NUnit.Framework;
using RestSharp;
using REstSharpDemo.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace REstSharpDemo.StepDefinitions
{
    [Binding]
    public class postPostSteps
    {
        SettingObj _obj;
        public postPostSteps(SettingObj obj) { 
            this._obj = obj;
        }

        [Given(@"I perform POST operation for ""([^""]*)""")]
        public void GivenIPerformPOSTOperationFor(string endpoint)
        {
            _obj.request = new RestRequest(endpoint, Method.POST);
        }

        [When(@"I perform operation for post having (.*), (.*) and (.*)")]
        public void WhenIPerformOperationForPostHavingHarryPotherAndAnyone(int id, string title, string author)
        {
            _obj.request.RequestFormat = DataFormat.Json; //Parameter to be passed needs to be parsed with the format of the body
            _obj.request.AddBody(new Data() { Id = id, Title = title, author = author });
        }

        [Then(@"I should see the expected author name as (.*)")]
        public void ThenIShouldSeeTheExpectedAuthorNameAsAnyone(string author)
        {
            //2nd way to Deserialize response coming from a request
            var response = _obj.client.Execute<Data>(_obj.request);
            Assert.That(response.Data.author, Is.EqualTo(author), "Name object is not the one created");
        }
    }
}
