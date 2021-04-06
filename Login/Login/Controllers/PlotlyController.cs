using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class PlotlyController : Controller
    {
        // GET: Plotly
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Plot_Scatter_Iris()
        {
            return View();
        }

    }
}