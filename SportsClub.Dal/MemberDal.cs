using System.Collections.Generic;
using System.Linq;
using SportsClub.Entities;

namespace SportsClub.Dal
{

    //moet public zijn want dezem oet bereikbaar zijn in Bll
    public class MemberDal
    {
        //CRUD operaties
        //Create, Read, Update, Delete

        //Read All
        public List<Member> ReadAll()
        {
            //database verbinding koppelen aan variabele
            var db = new SportsClubDbContext();
            //lijst van members uit databank opvragen
            List<Member> lstMembers = db.Members.ToList();
            //lijst met members teruggeven
            return lstMembers;
        }
    }
}