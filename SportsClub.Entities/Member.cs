using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Entities
{
    public class Member
    {
        // key property --> voor de Primary Key in de databank
        [Key]
        public int MemberId { get; set; } // Guid
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //een member kan deelnemen aan meerdere activiteiten
        //dus voorzien we een List<Activity> property
        public List<Activity> Activities { get; set; }

        // constructor zonder MemberId --> deze zal automatisch ingevuld worden
        public Member(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            //lege lijst van activiteiten genereren
            Activities = new List<Activity>();
        }

        // lege constructor, dit is vereist voor de Seed() methode
        public Member()
        {
            
        }
    }
}
