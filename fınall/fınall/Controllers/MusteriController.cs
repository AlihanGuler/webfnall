using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fınall.Controllers
{
    public class MusteriController : System.Web.Mvc.Controller
    {
        public ActionResult Edit(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var frma = session.Query<Models.Forma>().FirstOrDefault(x => x.Id == id);
                return View(frma);
            }
        }
        public ActionResult Index()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Musteriler = session.Query<Models.Musteri>().ToList();
                return View(Musteriler);
            }
        }
    }
}