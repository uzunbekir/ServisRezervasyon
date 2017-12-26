using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServisRezervasyon.DAL.Data;
using ServisRezervasyon.UI.DBContext;

namespace ServisRezervasyon.UI.Controllers
{
    public class MusterisController : Controller
    {
        private ServisDBContext db = new ServisDBContext();
        // GET
        public ActionResult Create()
        {
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Soyad,Telefon,Email")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.Musteris.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Create","Aracs");
            }

            return View(musteri);
        }
    }
}
