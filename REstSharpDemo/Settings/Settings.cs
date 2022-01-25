using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REstSharpDemo.Settings
{
    public class SettingObj
    {
        public RestClient client { get; set; }
        public RestRequest request { get; set; }
        //public RestResponse response { get; set; }
    }
}
