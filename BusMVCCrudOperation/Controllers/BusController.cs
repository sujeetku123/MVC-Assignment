using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BusMVCCrudOperation.Context;


namespace BusMVCCrudOperation.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        BusDataBaseEntities dbObj=new BusDataBaseEntities();
        public ActionResult Bus(BusTracking busTracking)
        {

            return View(busTracking);
        }

        [HttpPost]
        public ActionResult AddBus(BusTracking busTracking)
        {
            if (ModelState.IsValid) 
            {

                BusTracking obj = new BusTracking();
                obj.BusID = busTracking.BusID;  
                obj.BoardingPoint = busTracking.BoardingPoint;
                obj.TravelDate = busTracking.TravelDate;
                obj.Amount = busTracking.Amount;
                obj.Rating = busTracking.Rating;
                if (busTracking.BusID == 0)
                {
                    dbObj.BusTrackings.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(busTracking).State = EntityState.Modified;
                    dbObj.SaveChanges();

                    var list = dbObj.BusTrackings.ToList();
                    return View("BusList", list);

                }
                ModelState.Clear();
            }
            
            
            
            return View("Bus");
        }
        public ActionResult BusList()
        {
            var result = dbObj.BusTrackings.ToList();
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            var result = dbObj.BusTrackings.Where(x => x.BusID == id).First();
            dbObj.BusTrackings.Remove(result);
            dbObj.SaveChanges();

            var list = dbObj.BusTrackings.ToList();

            return View("BusList", list);
        }
    }
}