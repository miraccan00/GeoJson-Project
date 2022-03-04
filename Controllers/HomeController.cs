using Geomap.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Text;
using NetTopologySuite.IO;
using System.Text.Json;
using System;
using Newtonsoft.Json.Linq;

namespace Geomap.Controllers
{
    public class HomeController : Controller
    {
        [System.Obsolete]
        private IHostingEnvironment Environment;

        [System.Obsolete]
        public HomeController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

        GeoLocationContext db = new GeoLocationContext();
        public IActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        [System.Obsolete]
        public IActionResult Import(IFormFile postedFiles)
        {
            try
            {
                if (postedFiles.Length > 0)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    };
                    var jsonString = postedFiles.OpenReadStream().ToString();
                    string a = null;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        postedFiles.OpenReadStream().CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                        a = Encoding.UTF8.GetString(array);
                    }
                    Root data = JsonConvert.DeserializeObject<Root>(a);
                    List<GeoTable1> geoModels = new List<GeoTable1>();
                    GeoTable1 gm = new GeoTable1();
                    foreach (var veri in data.features)
                    {
                        var mycoordinates = JsonConvert.SerializeObject(veri.geometry);
                        geoModels.Add(
                            new GeoTable1
                            {
                                Id = veri.id,
                                Geometry = mycoordinates,
                                Propid = veri.properties.id,
                                Paftaadi = veri.properties.PaftaAdi,
                                Long = veri.properties.@long,
                                Lat = veri.properties.lat,
                                Zo = veri.properties.zo,
                                Sp = veri.properties.sp.ToString(),
                                Cur = veri.properties.cur.ToString(),
                                Ber = veri.properties.ber,
                                Kmetin = veri.properties.KMetin,
                                Ometin = veri.properties.OMetin,
                                Umetin = veri.properties.UMetin
                            }
                        );
                    }
                    db.GeoTable1s.AddRange(geoModels);
                    db.SaveChanges();
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
