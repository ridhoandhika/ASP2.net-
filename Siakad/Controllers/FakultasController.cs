using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Siakad.Models;

namespace Siakad.Controllers
{
    public class FakultasController : Controller
    {
        private SiakadConnection context =
            new SiakadConnection();

        

        // GET: Fakultas
        public ActionResult Index()
        {
            return View(context.Fakultas.ToList());
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Fakultas model)
        {
            if(ModelState.IsValid)
            {
                Fakultas item = new Fakultas()
                {
                    Id = Guid.NewGuid(),
                    KodeFakultas = model.KodeFakultas,
                    NamaFakultas = model.NamaFakultas,
                };
                context.Fakultas.Add(item);
                
                try
                {
                    context.SaveChanges();
                    return RedirectToAction("index");
                }
                catch (Exception) { }
            }
            return View(model);
        }
        public ActionResult Edit(string id)
        {
            Guid fkId = Guid.Parse(id);
            Fakultas model = context.Fakultas.Find(fkId);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fakultas model)
        {
            if(ModelState.IsValid)
            {
                Fakultas item = context.Fakultas.Find(model.Id);
                if(item !=null)
                {
                    item.KodeFakultas = model.KodeFakultas;
                    item.NamaFakultas = model.NamaFakultas;

                }
                try
                {
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception) { }
            }
            return View(model);
        }
        public ActionResult Delete(string id)
        {
            Guid fkId = Guid.Parse(id);
            Fakultas model = context.Fakultas.Find(fkId);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFakultas(string id)
        {
            Guid fkId = Guid.Parse(id);
            Fakultas model = context.Fakultas.Find(fkId);
            context.Fakultas.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ListFakultas()
        {
            //menampilkan data fakultas dari database
            List<Fakultas> ListFakultas = context.Fakultas.ToList();
            //membuat object viewBag ListFakultas,
            //kemudian diisi dari objek listfakultas
            ViewBag.ListFakultas = ListFakultas;
            //membuat objek Viewbag judul
            ViewBag.Judul = " Data List Fakultas";
            return View();
        }
    }
}