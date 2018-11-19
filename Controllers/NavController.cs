using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VahanBlog.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        //this is the controller for the navigation bar in the Car Portal.
        public PartialViewResult Menu()
        {
            IEnumerable<string> adminCat = new List<string>() { "Blog Posts", "Cars", "Makes" };
            return PartialView(adminCat);
        }
    }
}
