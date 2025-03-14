using SportsClub.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SportsClub.Dal
{
    public static class ActivityDal
    {
        public static List<Activity> ReadAll()
        {

            // using --> wanneer dit blokje code klaar is,
            // wordt de database connectie automatisch gesloten

            using (var db = new SportsClubDbContext())
            {
                //lijst van members uit databank opvragen
                List<Activity> lstActivities = db.Activities.ToList();
                //lijst met members teruggeven
                return lstActivities;
            }
        }
        public static Activity ReadOne(int id)
        {
            using (var db = new SportsClubDbContext())
            {
                //lid opvragen met id
                Activity activity = db.Activities.Find(id);
                //lid teruggeven
                return activity;
            }
        }
    }
}