﻿using System;
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

        //Create
        //hier moeten we parameters doorgeven die overeenstemmen met de properties
        //van de member class
        public static bool Create(string firstName, string lastName)
        {
            //trimmen van de voornaam en achternaam
            firstName = firstName.Trim();
            lastName = lastName.Trim();


            //controleren of de voornaam en achternaam niet leeg zijn
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {

                Member member = new Member(firstName, lastName);
                bool memberCreated = MemberDal.Create(member);
                return memberCreated;
            }

            //indien de voornaam of achternaam leeg is, geven we false terug
            return false;

        }

        public static bool Delete(int id)
        {
            try
            {
                Member member = MemberDal.ReadOne(id);

                bool memberDeleted = MemberDal.Delete(member);
                return memberDeleted;
            }
            catch
            {

                return false;
            }
        }
    }
}