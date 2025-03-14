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
    }
}
