using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace SocialMediaReader.Models.SocialMedia
{
    public class SocialMediaClient
    {
        public string baseUrl { get; set; }


        //you need the user manager and HttpContext to get the Access Token
        public HttpContextBase HttpContext { get; set; }
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //Provider Key is Facebook/Insta/etc - literally just the name. facebook is all lower case
        public string ProviderKey { get; set; }
        public string AccessToken { get; set; }

        //gets userid
        public async Task<System.Security.Claims.Claim> GetAccessToken()
        {
            if (HttpContext == null)
            {
                return (null);
            }

            string userId = HttpContext.User.Identity.GetUserId();

            return (await GetAccessToken(userId));
        }

        public async Task<System.Security.Claims.Claim> GetAccessToken(string userId)
        {
            //Get Access Token
            var currentClaims = await UserManager.GetClaimsAsync(userId);

            var accesstoken = currentClaims.FirstOrDefault(x => x.Type == String.Format("urn:tokens:{0}", ProviderKey));

            if (accesstoken == null)
            {
                return (null);
            }
            //this is just the string value of the access token, not the claim that this function returns
            AccessToken = accesstoken.Value;

            return (accesstoken);
        }

        public async Task<dynamic> GetLI(string url, string access_token = "")
        {

            //Generate a WebRequest using the URL
            //generates a blank access_token for the body, which is overwritten by the access_token for Linkedin
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Add("Authorization: Bearer " + access_token);

            //Ask for data from the server
            using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());

                //Place result into a string
                string result = await reader.ReadToEndAsync();

                //Convert result to JSON Object
                dynamic jsonObj = System.Web.Helpers.Json.Decode(result);

                return (jsonObj);
            }

        }
        public async Task<dynamic> GetFB(string url)
        {

            //Generate a WebRequest using the URL
            //generates a blank access_token for the body, which is overwritten by the access_token for Linkedin
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";

            //Ask for data from the server
            using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());

                //Place result into a string
                string result = await reader.ReadToEndAsync();

                //Convert result to JSON Object
                dynamic jsonObj = System.Web.Helpers.Json.Decode(result);

                return (jsonObj);
            }
        }
    }
}