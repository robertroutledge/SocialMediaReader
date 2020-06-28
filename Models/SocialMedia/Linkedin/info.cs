using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Helpers;

namespace SocialMediaReader.Models.SocialMedia.Linkedin
{
    public class info
    {
        public dynamic jsonObj2 { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string id { get; set; }

        public info(dynamic json)
        {
            jsonObj2 = json;
            firstName = jsonObj2.firstName.localized.en_us;
            lastName = jsonObj2.lastName.localized.en_us;
            id = jsonObj2.id;

        }


    }
}