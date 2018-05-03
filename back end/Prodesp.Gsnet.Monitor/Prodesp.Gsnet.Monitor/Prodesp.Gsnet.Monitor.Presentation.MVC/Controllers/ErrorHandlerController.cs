using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodesp.Gsnet.Monitor.Presentation.MVC.Controllers
{
    public class ErrorHandlerController : Controller
    {
        private readonly IDictionary<int, string> PageTable;
        public ErrorHandlerController()
        {
            this.PageTable = new Dictionary<int, string>();

            this.PageTable.Add(401, "UnAuthorizedAccess");
            this.PageTable.Add(404, "NotFound");
            this.PageTable.Add(500, "InternalServerError");

        }
        public ActionResult HandleError(int id, string status)
        {
            string page = this.PageTable[id];
            TempData["status"] = status;
            return View(page ?? "InternalServerError");
        }
    }
}