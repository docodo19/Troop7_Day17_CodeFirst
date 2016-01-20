namespace Day17_CodeFirst.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Day17_CodeFirst.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Day17_CodeFirst.Models.ApplicationDbContext context)
        {
            var movies = new Movie[]
            {
                new Movie { Title = "Star Wars", Director = "Lucas" },
                new Movie { Title = "Ex Machina", Director = "Garland" },
                new Movie { Title = "King Kong", Director = "Jackson" }
            };

            context.Movies.AddOrUpdate(m => m.Title, movies);

        }
    }
}
