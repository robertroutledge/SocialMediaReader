using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace SocialMediaReader.Models.SocialMedia.Linkedin
{
    public class info
    {
        public dynamic jsonObj { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string pictureurl { get; set; }      


        public info(dynamic json)
        {
            jsonObj = json;
            
            firstName = jsonObj.firstName;
            //lastName = jsonObj.lastName.localized;
            //pictureurl = jsonObj.profilePicture.displayImage\~.elements.\3.data.identifiers;

            //if (jsonObj.pictureurl != null)
            //{
    
            //}
        }



    }
}