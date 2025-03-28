using SportsClub.Bll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsClub.Entities;

namespace SportsClub.WebApp.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            try
            {
                List<Activity> lstActivities = ActivityBll.ReadAll();
                //lijst met members uit databank opvragen
                //opslaan in list en dan doorgeven aan view
                return View(lstActivities);
            }
            catch (Exception ex)
            {
                //foutboodschap tonen
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                Activity m = ActivityBll.ReadOne(id);
                return View(m);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string activityName, int maxParticipants, HttpPostedFileBase picture)
        {
            string pictureName = "unknown.png";

            if (picture != null)
            {
                if (picture.ContentType == "image/jpeg" || picture.ContentType == "image/png")
                {
                    string pathToSave = Server.MapPath("~/Content/images/activitypics/");
                    string pictureExtension = Path.GetExtension(picture.FileName);
                    pictureName = Guid.NewGuid() + pictureExtension;
                    picture.SaveAs(pathToSave + pictureName);

                }
            }
            
            bool activityCreated = ActivityBll.Create(activityName, maxParticipants, pictureName);
                if (activityCreated)
                {
                    ViewBag.Feedback = activityName + " created";
                }
                else
                {
                    ViewBag.Feedback = "Activity not created";
                }

                return View();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Activity a = ActivityBll.ReadOne(id);
                return View(a);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            int activityId = Convert.ToInt32(id);
            bool activityDeleted = ActivityBll.Delete(activityId);
            if (activityDeleted)
            {
                TempData["Feedback"] = "Activity deleted";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                Activity a = ActivityBll.ReadOne(id);
                return View(a);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(int activityId, string ActivityName, int MaxParticipants)
        {
            bool activityUpdated = ActivityBll.Update(activityId, ActivityName, MaxParticipants);
            if (activityUpdated)
            {
                TempData["Feedback"] = "Activity updated";
                return RedirectToAction("Details", new {id = activityId});
            }
            else
            {
                TempData["Feedback"] = "Activity not updated";
                return View("Error");
            }
        }
    }
}

