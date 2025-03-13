using SportsClub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsClub.WebApp.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Index()
        {
            // test lijst met members aanmaken
            List<Member> lstMembers = new List<Member>();
            // test members toevoegen aan list
            lstMembers.Add(new Member("Louis", "Demuynck"));
            lstMembers.Add(new Member("Zakaria", "Atari"));
            // list doorgeven aan view
            return View(lstMembers);
        }
    }
}