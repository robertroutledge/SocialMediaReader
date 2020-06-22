using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SocialMediaReader.Models.SocialMedia.Facebook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SocialMediaReader.Controllers
{
    

    [Authorize]
    public class FacebookController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Posts()
        {
            FacebookClient facebookClient = new FacebookClient();
            facebookClient.HttpContext = HttpContext;

            postss posts = await facebookClient.posts();

            return (View(posts));
            
        
        }
    }
}