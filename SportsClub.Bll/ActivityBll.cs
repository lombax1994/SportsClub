using SportsClub.Dal;
using SportsClub.Entities;
using System.Collections.Generic;
using System;

namespace SportsClub.Bll
{
    public static class ActivityBll
    {
        public static List<Activity> ReadAll()
        {
            List<Activity> lstActivities = ActivityDal.ReadAll();

            //controleren of we effectief een correcte lijst krijgen
            //en of deze lijst niet leeg is
            if (lstActivities == null || lstActivities.Count == 0)
            {
                throw new Exception("No members found");
            }

            return lstActivities;
        }

        public static Activity ReadOne(int id)
        {
            Activity activity = ActivityDal.ReadOne(id);

            if (activity == null)
            {
                throw new Exception("Member not found");
            }

            return activity;
        }

        public static bool Create(string activityName, int maxParticipants)
        {
            activityName = activityName.Trim();



            if (!string.IsNullOrEmpty(activityName))
            {
                Activity activity = new Activity(activityName, maxParticipants);
                bool activityCreated = ActivityDal.Create(activity);
                return activityCreated; 
            }
            return false;
        }

        public static bool Delete(int id)
        {
            try
            {
                Activity a = ActivityDal.ReadOne(id);
                bool ActivityDeleted = ActivityDal.Delete(a);
                return ActivityDeleted;
            }
            catch
            {
                return false;
            }
        }
    }
}
