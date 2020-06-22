using SocialMediaReader.Models.SocialMedia.Linkedin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SocialMediaReader.Controllers
{
    [Authorize]
    public class LinkedinController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> LIPosts()
        {
            LinkedinClient linkedinclient = new LinkedinClient();
            linkedinclient.HttpContext = HttpContext;

            info info = await linkedinclient.posts();
            ViewBag.JSON = info;
            return (View(info));
        }
    }
}