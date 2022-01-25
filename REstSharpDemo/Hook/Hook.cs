using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using REstSharpDemo.Settings;
using RestSharp;

namespace REstSharpDemo.Hook
{   [Binding]
    public class Hook
    {
        private SettingObj _obj;
        public Hook(SettingObj obj) {
            this._obj = obj;
        }

        [BeforeScenario]
        public void setup() {
            string baseURl = ConfigurationManager.AppSettings["baseUrl"];
            _obj.client = new RestClient(baseURl);
        }
    }
}
