using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fınall.Controllers
{
    public class FormaController : System.Web.Mvc.Controller
    { 
       public ActionResult Index()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Formalar = session.Query<Models.Forma>().Fetch(x => x.Musteriler).ToList();
                return View(Formalar);
            }
        }

        public ActionResult Listele()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Formalar = session.Query<Models.Forma>().ToList();
                return View(Formalar);
            }
        }

        public ActionResult Yeni()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Forma = session.Query<Models.Forma>().FirstOrDefault(x => x.Id == id);
                return View(Forma);
            }
        }


        [HttpPost]
        public ActionResult Edit(Models.Forma Forma)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var frm = session.Query<Models.Forma>().FirstOrDefault(x => x.Id == Forma.Id);
                frm.TakımAdı = Forma.TakımAdı;
                frm.Fiyat = Forma.Fiyat;
                session.SaveOrUpdate(frm);
                session.Flush();
                return RedirectToAction("/Index");
            }
        }
    }
}