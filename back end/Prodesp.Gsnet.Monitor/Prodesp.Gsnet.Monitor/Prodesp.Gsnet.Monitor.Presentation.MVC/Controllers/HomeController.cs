using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodesp.Gsnet.Monitor.Presentation.MVC.Controllers
{
    public class HomeController : Controller
    {
        //[HttpPost]
        //public ActionResult Index(string atk, string jwt, string img, string mnu)
        //{
        //    if (!this.VerificarExistenciaAccessToken())
        //        throw new UnauthorizedAccessException("Acesso Negado");

        //    ViewBag.AccessToken = atk;
        //    ViewBag.JWT = jwt;
        //    ViewBag.UserImage = img;
        //    ViewBag.Menus = mnu;
        //    return View();
        //}

        public ActionResult Index()
        {
            return this.CarregarMonitor();
        }
        public ActionResult CarregarMonitor()
        {
            //if (!base.VerificarExistenciaAccessToken())
            //    throw new UnauthorizedAccessException("Você não está logado ou sua sessão expirou");

            return View("Index");
        }

    }
}