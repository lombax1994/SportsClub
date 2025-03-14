using System;
using System.Collections.Generic;
using SportsClub.Dal;
using SportsClub.Entities;

namespace SportsClub.Bll
{
    public static class MemberBll
    {
        //CRUD 

        //Read All
        public static List<Member> ReadAll()
        {
            List<Member> lstMembers = MemberDal.ReadAll();

            //controleren of we effectief een correcte lijst krijgen
            //en of deze lijst niet leeg is
            if (lstMembers == null || lstMembers.Count == 0)
            {
                throw new Exception("No members found");
            }

            return lstMembers;
        }

        public static Member ReadOne(int id)
        {
            Member member = MemberDal.ReadOne(id);

            if (member == null)
            {
                throw new Exception("Member not found");
            }

            return member;
        }
    }
}