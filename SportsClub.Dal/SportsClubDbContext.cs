using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsClub.Entities; // enkel mogelijk als er al een reference toegevoegd werd naar SportsClub.Entities

namespace SportsClub.Dal
{
    class SportsClubDbContext : DbContext // overerven van DbContext class uit EntityFramework
    {
        // properties --> dit worden uiteindelijk tabellen in mijn db
        // de naam van de property wordt dan de naam van de tabel in de db
        public DbSet<Member> Members { get; set; }
        public DbSet<Activity> Activities { get; set; }

        // in de constructor leggen we de link naar onze database server
        // en de specifieke databank die we willen bereiken
        public SportsClubDbContext() : base(@"Data Source=.\sqlexpress;Initial Catalog=SportsClubDb;User Id=creo;Password=creo")
        {
            
        }

        // database commando's
        // uit te voeren in de package manager console
        // geen console? bovenaan Tools > NuGet Package Manager > Package Manager Console

        // eerste commando: enable-migrations
        // dit commando moet je maar één keer uitvoeren, namelijk de
        // allereerste keer dat je de verbinding met je database server maakt

        // EntityFramework6\enable-migrations --> meestal moet het stukje EntityFramework6\ er NIET bij

        // tweede commando: add-migration <naam>
        // dit commando voer je uit telkens je een wijziging aanbrengt
        // in je Entities classes
        // add-migration zet een wijziging klaar voor de databank
        // gebaseerd op de code uit onze Entities classes

        // EntityFramework6\add-migration CreateDb

        // derde commando: update-database
        // dit commando voer je uit om de wijzigingen die klaarstaan
        // in de databank effectief uit te voeren

        // EntityFramework6\update-database
    }
}
