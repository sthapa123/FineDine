namespace FineDine.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<FineDine.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "FineDine.Models.ApplicationDbContext";
        }

        protected override void Seed(FineDine.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            /* var Establishments = new List<Establishment>()
             {
                 new Establishment() {Name = "Pekara Juri�", Address ="�imi�eva 2", Description="Pekara vrlo atraktivnih peciva."},
                 new Establishment() {Name = "Restoran Apetit", Address ="Vo�ni trg 7", Description="Jeftin restoran u centru grada."},
             };

             var Locations = new List<Location>()
             {
                 new Location() {City="Solin", Country = "Croatia", PostCode = "21210" },
                 new Location() {City="Split", Country = "Croatia", PostCode = "21000" },
             };

             Establishments[0].Location = Locations[0];
             Establishments[1].Location = Locations[1];

             var DbUsersList = context.Users.ToList();

             Establishments[0].Owner = DbUsersList[0];
             Establishments[1].Owner = DbUsersList[0];

             Locations[0].Establishments = new List<Establishment>() { Establishments[0] };
             Locations[1].Establishments = new List<Establishment>() { Establishments[1] };

             Establishments.ForEach(estbl => context.Establishments.Add(estbl));
             Locations.ForEach(loc => context.Locations.Add(loc));

             */

            /*
            var IdentityRoles = new List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>()
            {
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() {Name = "Administrator" },
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() {Name = "PersonalUser" },
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() {Name = "BusinessUser" },
            };

            IdentityRoles.ForEach(ir => context.Roles.Add(ir));
            

            var Categories = new List<Category>()
             {
                 new Category() {Name = "Restaurant" },
                 new Category() {Name = "Fast Food" },
                 new Category() {Name = "Bar" },
                 new Category() {Name = "Coffee Shop" }
             };

            Categories.ForEach(cat => context.Categories.Add(cat));
            

            var comments = new List<Comment>()
             {
                 new Comment() {Content = "Ukusno", Rating = 4, DateTime = DateTime.Today },
                 new Comment() {Content = "Zagonetno", Rating = 5, DateTime = DateTime.Today }
             };

            comments.ForEach(c => context.Comments.Add(c));*/
        }
    }
}