using System.Collections.Generic;
using System.Linq;
using SportsClub.Entities;

namespace SportsClub.Dal
{

    //moet public zijn want dezem oet bereikbaar zijn in Bll
    public static class MemberDal
    {
        //CRUD operaties
        //Create, Read, Update, Delete

        //Read All
        public static List<Member> ReadAll()
        {

            // using --> wanneer dit blokje code klaar is,
            // wordt de database connectie automatisch gesloten

            using (var db = new SportsClubDbContext())
            {
                //lijst van members uit databank opvragen
                List<Member> lstMembers = db.Members.ToList();
                //lijst met members teruggeven
                return lstMembers;
            }
        }

        //Read One
        public static Member ReadOne(int id)
        {
            using (var db = new SportsClubDbContext())
            {
                //lid opvragen met id
                Member member = db.Members.Find(id);
                //lid teruggeven
                return member;
            }
        }
    }
}