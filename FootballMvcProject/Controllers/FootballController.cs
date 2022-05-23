using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrudOperation.Context;
using System.Data;
namespace MvcCrudOperation.Controllers
{
    public class FootballController : Controller
    {
        // GET: Football
        TestEntities dbobj=new TestEntities();
        public ActionResult Football(FootBallLeague footBallLeague)
        {
           
           
                return View(footBallLeague);
        }

        [HttpPost]
        /*Performing Insert Operation*/
        public ActionResult AddFootball(FootBallLeague model)
        {
            if (ModelState.IsValid) {
                FootBallLeague footBallLeague = new FootBallLeague();
                footBallLeague.MatchId = model.MatchId;
                footBallLeague.TeamName1 = model.TeamName1;
                footBallLeague.TeamName2 = model.TeamName2;
                footBallLeague.MatchStatus = model.MatchStatus;
                footBallLeague.WinningTeam = model.WinningTeam;
                footBallLeague.Points = model.Points;

                if (model.MatchId != 0)
                {
                    dbobj.FootBallLeagues.Add(footBallLeague);
                    dbobj.SaveChanges();
                }

            }
            ModelState.Clear();


            return View("Football");
        }
        [HttpPost]
        /*Performing Update Operation*/
        public ActionResult UpdateFootball(FootBallLeague model)
        {
            if (ModelState.IsValid)
            {
                FootBallLeague footBallLeague = new FootBallLeague();
                footBallLeague.MatchId = model.MatchId;
                footBallLeague.TeamName1 = model.TeamName1;
                footBallLeague.TeamName2 = model.TeamName2;
                footBallLeague.MatchStatus = model.MatchStatus;
                footBallLeague.WinningTeam = model.WinningTeam;
                footBallLeague.Points = model.Points;

                if (model.MatchId == footBallLeague.MatchId)
                {
                    /*Performing Updation*/
                    dbobj.Entry(footBallLeague).State = EntityState.Modified;
                    dbobj.SaveChanges();

                    var list = dbobj.FootBallLeagues.ToList();
                    return View("FootballList", list);

                }

            }
            ModelState.Clear();


            return View("Football");
        }
        /*Displaying the  Data base table data In a View*/
        public ActionResult FootballList()
        {
            var result = dbobj.FootBallLeagues.ToList();
            return View(result);  
        }
        /* performing delete Operation*/ 
        public ActionResult Delete(int id)
        {
            var result = dbobj.FootBallLeagues.Where(x=>x.MatchId == id ).First();
            dbobj.FootBallLeagues.Remove(result);
            dbobj.SaveChanges();

            var list = dbobj.FootBallLeagues.ToList();

            return View("FootballList",list);
        }
    }
}