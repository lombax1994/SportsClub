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
                List<Member> lstMembers = MemberBll.ReadAll();
                //lijst met members uit databank opvragen
                //opslaan in list en dan doorgeven aan view
                return View(lstMembers);
            }
            catch (Exception ex)
            {
                //foutboodschap tonen
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public ActionResult Details(int id) {
            try
            {
                Member m = MemberBll.ReadOne(id);
                return View(m);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        //Create
        //twee methodes nodig: de eerste maakt de link naar de view aan
        //de tweede verwerkt de gegevens die via het formulier verstuurd worden om
        //zo een member met voornaam en familienaam in de databank aan te maken
        
        public ActionResult Create()
        {
            return View();
        }

        //parameters moeten exact gespeld zijn zoals de properties van de member class
        //HttpPost --> Dit is de methode die aangesproken wordt wanneer het formulier
        //verstuurd wordt
        [HttpPost]
        public ActionResult Create(string firstName, string lastName)
        {   
            
                bool memberCreated = MemberBll.Create(firstName, lastName);
                if (memberCreated)
                {
                    //Feedback boodschop plaatsen in de Viewbag
                    ViewBag.Feedback = firstName + " " + lastName + " added to the database";
                }
                else
                {
                    //feedback boodschap plaatsen in de Viewbag
                    ViewBag.Feedback = "Something went wrong - failed to add member.";
                }
                //opnieuw naar de Create view gaan
                //en feedback boodschap tonen
                return View();
        }
    }
}