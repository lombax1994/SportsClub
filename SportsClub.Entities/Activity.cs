using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Entities
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        [Required(ErrorMessage = "Naam mag niet leeg zijn.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Lengte naam tussen {2} en {1}")]
        public string Activityname { get; set; }

        [Required(ErrorMessage="Aantal deelnemers mag niet leeg zijn")]
        [Range(6, 30, ErrorMessage = "Aantal deelnemers moet tussen {1} en {2} liggen")]
        public int MaxParticipants { get; set; } // aantal ingeschrevenen voor een activiteit

        public List<Member> Members { get; set; }

        public string Picture { get; set; }

        public Activity(string activityName, int maxParticipants, string picture)
        {
            Activityname = activityName;
            MaxParticipants = maxParticipants;
            Members = new List<Member>();
            Picture = picture;

        }

        // lege constructor voor de Seed() methode
        public Activity()
        {
            
        }
    }
}
