using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileMVCShope.Models;
using System.Data.Entity;

namespace MobileMVCShope.Controllers
{
    public class MobileController : Controller
    {
        //Database object creation
        MobileEntities mobileEntities = new MobileEntities();
        // GET: Mobile
        public ActionResult ShowMobiles()
        {
            var mobilelist = mobileEntities.tblMobiles.ToList();

            return View(mobilelist);
        }
        public ActionResult InsertMobile()
        {
            //added insertmobile action
            return View();
        }
        public ActionResult EditMobile(int id)
        {
            var mobiledata = mobileEntities.tblMobiles.Find(id);
            return View(mobiledata);
        }
        [HttpPost]
        public ActionResult EditMobile(tblMobile mobiledata)
        {
            mobileEntities.Entry(mobiledata).State = EntityState.Modified;
            mobileEntities.SaveChanges();
            return RedirectToAction("ShowMobiles");
        }
        public ActionResult DeleteMobile()
        {
            return View();
        }
        public string ShowData()
        {
            return "Data";
        }
    }
}