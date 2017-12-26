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
    public class RandevusController : Controller
    {
        private ServisDBContext db = new ServisDBContext();
        // GET
        public ActionResult Index()
        {
            var Bekleyen = db.Randevus.Where(ra => ra.OnaylandıMı == false);
            return View(Bekleyen.ToList());
        }

        // GET
        public ActionResult Onaylanmis()
        {
            var Onaylanmis = db.Randevus.Where(ra => ra.OnaylandıMı == true);
            return View(Onaylanmis.ToList());
        }
        // GET
        public ActionResult Create()
        {
            ViewBag.AracId = new SelectList(db.Aracs.OrderByDescending(m => m.Id).Take(1), "Id", "Plaka");
            ViewBag.MusteriId = new SelectList(db.Musteris.OrderByDescending(m => m.Id).Take(1), "Id", "Ad");
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tarih,AracId,MusteriId")] Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                db.Randevus.Add(randevu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AracId = new SelectList(db.Aracs.OrderByDescending(m => m.Id).Take(1), "Id", "Plaka");
            ViewBag.MusteriId = new SelectList(db.Musteris.OrderByDescending(m => m.Id).Take(1), "Id", "Ad");
            return View(randevu);
        }
        // GET
        public ActionResult Onayla(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Randevu randevu = db.Randevus.Find(id);
            randevu.OnaylandıMı = true;
            if (randevu == null)
            {
                return HttpNotFound();
            }
            return View(randevu);
        }
        // POST
        [HttpPost, ActionName("Onayla")]
        [ValidateAntiForgeryToken]
        public ActionResult OnaylamaIslemi(int id)
        {
            Randevu randevu = db.Randevus.Find(id);
            randevu.OnaylandıMı = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
