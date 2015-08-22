using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ODirigente.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Flamengo");
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    Session["Jogandores"] = new List<string> {"ronaldo", "ronaldinho"};
        //    var viewModel = new ViewModelZord {Jogadores = (List<string>) Session["Jogandores"]};

        //    return View(viewModel);
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }

    public class ViewModelZord
    {
        public List<string> Jogadores { get; set; }
    }
}