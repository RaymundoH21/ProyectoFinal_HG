using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal_HG.Models;

namespace ProyectoFinal_HG.Controllers
{
    [Authorize]
    public class PrincipalController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Principal
        public ActionResult Index()
        {
            var ropas = db.Ropas.Include(a => a.Modista).ToList();
            return View(ropas);
        }
    }
}