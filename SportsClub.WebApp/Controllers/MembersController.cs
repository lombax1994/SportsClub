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

        //Delete
        //twee methodes nodig: de eerste maakt de link naar de view te doen werken.
        //en eentje om de delete uit te voeren

        public ActionResult Delete(int id)
        {
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

        //tweede methode om de delete uit te voeren
        // [HttpPost] --> deze methode wordt aangesproken wanneer het formulier verstuurd wordt
        [HttpPost]
        //parameter id is hier een string omdat we al een methode hebben
        //met dezelfde naam en dezelfde parameters
        public ActionResult Delete(string id)
        {
            int memberId = Convert.ToInt32(id);
            try
            {
                bool memberDeleted = MemberBll.Delete(memberId);
                if (memberDeleted)
                {
                    TempData["Feedback"] = "Member deleted";
                    //we moeten werken met RedirectToAction omdat we de volledige
                    //index methode willen uitvoeren
                    return RedirectToAction("Index");
                }
                return View("Error");
                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        //Edit
        //twee methodes nodig: de eerste maakt de link naar de view te doen werken.
        //en eentje om de edit uit te voeren

        public ActionResult Edit(int id)
        {
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
    }
}