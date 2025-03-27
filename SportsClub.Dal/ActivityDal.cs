using SportsClub.Entities;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static bool Create(Activity a)
        {
            using (var db = new SportsClubDbContext())
            {
                //lid toevoegen aan databank
                try
                {
                    db.Activities.Add(a);
                    //aangepaste databank opslaan
                    int numberOfChanges = db.SaveChanges();
                    //aantal wijzigingen teruggeven
                    if (numberOfChanges > 0) return true;
                    return false;
                }
                catch
                {

                    return false;
                }
            }
        }

        public static bool Delete(Activity a) {
            using (var db = new SportsClubDbContext())
            {
                db.Entry(a).State = EntityState.Deleted;
                int i = db.SaveChanges();
                if(i>0) return true;
                return false;
            }
        }

    }
}