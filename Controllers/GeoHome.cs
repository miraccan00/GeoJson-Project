using Geomap.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Geomap.Controllers
{
    public class GeoHome : Controller
    {
        public IActionResult Index()
        {
            var context = new GeoLocationContext();
            var data = context.GeoTable1s.ToList();
            return View(data);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            var context = new GeoLocationContext();
            var data = context.GeoInfo.Where(x => x.Geoid == id).FirstOrDefault();
            return View(data);
        }
    }
}
