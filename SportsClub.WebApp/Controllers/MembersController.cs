using SportsClub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsClub.Bll;

namespace SportsClub.WebApp.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Index()
        {

            try
            {
                List<Member> lstMembers = new MemberBll().ReadAll();
                //lijst met members uit databank opvragen
                //opslaan in list en dan doorgeven aan view
                return View(lstMembers);
            }
            catch (Exception ex)
            {
                //foutboodschap tonen
                ViewBag.Foutboodschap = ex.Message;
                return View("Error");
            }
        }
    }
}