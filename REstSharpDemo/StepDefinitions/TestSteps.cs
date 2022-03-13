using System;
using TechTalk.SpecFlow;
using RestSharp;
using System.Text.Json;
using NUnit.Framework;
using System.Configuration;
using REstSharpDemo.Settings;
using REstSharpDemo.Utilities;
using REstSharpDemo.Services;
using REstSharpDemo.Mappings;

namespace REstSharpDemo.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        private ReqResServices _services;
        private IRestResponse restResponse;
        public StepDefinitions(ReqResServices services) {
            this._services = services; 
        }
        //Remember when using a data coming from appSetting.config file
        //We must change to static the property/variable/object we are using
        //within a Gerkin Keyword used by specflow to use it
        private string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        //static RestClient client = new RestClient(baseURl);

        [Given(@"I perform GET operation for getting user list")]
        public void GivenIPerformGETOperationFor()
        {
            restResponse = _services.GetUserList(baseUrl, "api/users?page=2");
        }

        [Then(@"I should see the expected authorname as ""([^""]*)""")]
        public void ThenIShouldSeeTheNameAs(string expectedValue)
        {
            UserList content = _services.getContent<UserList>(restResponse);
            var firstName = content.Data[0].First_Name;
            Assert.That(firstName, Is.EqualTo(expectedValue), "Author is not correct");
        }

        [Given(@"I perform POST operation for creating an user with (.*) and (.*)")]
        public void GivenIPerformPOSTOperationFor(string name, string job)
        {
            restResponse = _services.createUser(baseUrl, "api/users", new CreateUser() {Name = name, Job = job});
        }

        [Then(@"I should see the expected name as (.*)")]
        public void ThenIshouldSeeTheExpectedNameSs(string expectedValue)
        {
            CreateUser content = _services.getContent<CreateUser>(restResponse);
            var name = content.Name;
            Assert.That(name, Is.EqualTo(expectedValue), "Name is not correct");
        }

        [Given(@"I perform PUT operation for updating an user with (.*) and (.*)")]
        public void GivenIPerformPUTOperationFor(string name, string job)
        {
            restResponse = _services.updateUser(baseUrl, "api/users", new CreateUser() { Name = name, Job = job });
        }

        [Then(@"I should see the updated job as (.*)")]
        public void ThenIshouldSeeTheUpdatedJobAs(string expectedValue)
        {
            CreateUser content = _services.getContent<CreateUser>(restResponse);
            var job = content.Job;
            Assert.That(job, Is.EqualTo(expectedValue), "Updated job is not the correct one");
        }
    }
}
