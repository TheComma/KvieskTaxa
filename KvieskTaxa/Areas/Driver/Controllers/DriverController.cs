using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KvieskTaxa.Database;

namespace KvieskTaxa.Areas.Driver.Controllers
{
    public class DriverController : Controller
    {
        private DataModelContext dbContext;
        public ActionResult showCalls()
        {
            return View(dbContext.Calls.ToList());
        }
        public void openCallInfo()
        {

        }
        public void changeDriverState()
        {

        }
        public void acceptCall()
        {

        }
        public void receiveCall()
        {

        }

    }
}