using System;
using System.Collections.Generic;
using SportsClub.Dal;
using SportsClub.Entities;

namespace SportsClub.Bll
{
    public class MemberBll
    {
        //CRUD 

        //Read All
        public List<Member> ReadAll()
        {
            List<Member> lstMembers = new MemberDal().ReadAll();

            //controleren of we effectief een correcte lijst krijgen
            //en of deze lijst niet leeg is
            if (lstMembers == null || lstMembers.Count == 0)
            {
                throw new Exception("No members found");
            }

            return lstMembers;
        }
    }
}