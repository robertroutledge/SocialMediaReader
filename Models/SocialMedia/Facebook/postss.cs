using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

//need to fix this, it isn't building the list properly. Use the written code from the assignment, not the video
namespace SocialMediaReader.Models.SocialMedia.Facebook
{
    public class postss
    {
        public dynamic jsonObj { get; set; }
        public postss(dynamic json)
        {
            jsonObj = json;
            id = jsonObj.id;
            name = jsonObj.name;
            birthday = jsonObj.birthday;

            if (jsonObj.likes != null)
            { 
                likes = new likes(jsonObj.likes);
            }
        }       
            
        public string id { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
        public likes likes { get; set; }
    }

    public class likes
    {
        public dynamic jsonObj { get; set; }

        public likes(dynamic json)
        {
            jsonObj = json;
            
            if(jsonObj != null)
            {
                if(jsonObj.data != null)
                {
                    data = new like[jsonObj.data.Length];

                    for(int i = 0; i <data.Length; i++)
                    {
                        data[i] = new like(jsonObj.data[i]);
                    }
                }
            }
        }
 
        
       public like[] data { get; set; }
    }

    public class like
    {
        public string name { get; set; }
        public string id { get; set; }
        public string createdtime { get; set; }
        public dynamic jsonObj { get; private set; }
        private string _createdtime { get; set; }

        public like(dynamic json)
        {
        jsonObj = json;
        
            if (jsonObj != null)
            {
                id = jsonObj.id;
                name = jsonObj.name;
                _createdtime = Convert.ToString(jsonObj.created_time);
                createdtime = _createdtime.Substring(0, 10);

            }
        }
    }     
}