using System.Runtime.InteropServices;

namespace SportsClub.Dal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SportsClub.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<SportsClub.Dal.SportsClubDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportsClub.Dal.SportsClubDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // de Seed() methode wordt telkens uitgevoerd
            // wanneer je het update-database commando in de console gebruikt

            // een paar test members toevoegen aan de database
            // het x => ... stukje is om te voorkomen dat er dubbele data telkens bij komt
            context.Members.AddOrUpdate(
                x => new { x.FirstName, x.LastName },
                new Member("Koenraad", "Pecceu", "unknown.jpg"),
                new Member("Sam", "Vaneeckhoutte", "unknown.jpg"),
                new Member("Mieke", "Lapeire", "unknown.jpg")
            );

            // een paar test activiteiten toevoegen aan de database
            context.Activities.AddOrUpdate(
                x => x.Activityname,
                new Activity("Voetbal", 30, "unknown.png"),
                new Activity("Tennis", 15, "unknown.png")
                );
        }
    }
}
