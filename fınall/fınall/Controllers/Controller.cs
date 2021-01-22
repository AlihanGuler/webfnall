using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace fınall.Controllers
{
    public class Controller : System.Web.Mvc.Controller
    {
        public ActionResult Yeni()
        {
            return View();
        }
        public ActionResult Listele2()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                //var Forma = session.Get<Models.Forma>(1);

                var musteri = session.Query<Models.Musteri>().Where(x => x.Id == 1).FirstOrDefault();
                var frmYeni = new Models.Forma() { Fiyat = "333333", TakımAdı = "gsw", };

                var Musteri = new Models.Musteri() { Ad = "Alihan", Soyad = "Güler" };
                Musteri.Forma = frmYeni;

                // var musteri = new Models.Musteri();
                //musteri.Ad = "Nilufer";
                //musteri.Soyad = "Ok";
                //Musteri.Forma= frmYeni;

                frmYeni.Musteriler.Add(musteri);

                session.SaveOrUpdate(Musteri);
                session.Flush();

                var forma = session.Query<Models.Forma>().Where(x => x.TakımAdı == "Lakers").FirstOrDefault();
                musteri.Forma = frmYeni;


                //var k = forma.Musteriler;
                //linq query

                //frmYeni.TakımAdı = "Brooklyn Nets";
                //frmYeni.Fiyat = "2213211";
                //var FRMQ = session.Query<Models.Forma>().Where(x => x.Fiyat == "2322").ToList();
                //rollback 
                //commit

                //var frm = new Models.Forma()
                //{
                //  TakımAdı = "GSW",
                //Fiyat = "312 2121211",

                // };

                var frma = session.Query<Models.Forma>().FirstOrDefault(x => x.Id == 1);

                session.SaveOrUpdate(frma);

                session.Delete(frma);

            }


            return View();
        }
    }

}