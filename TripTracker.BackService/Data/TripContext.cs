using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TripTracker.Backservice.Models;

namespace TripTracker.BackService.Data
{
    public class TripContext:DbContext //register a db context
    {
        /*
         * when we dont wish to track the context of query, we can do this
         * or we can do it in controller itself as shown in TripsController.cs
        public TripContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        */

        public TripContext(DbContextOptions<TripContext> options) : base(options) { }

        public DbSet<Backservice.Models.Trip> Trips { get; set; }

        /*
         * used to override convention if you wish to rename the key property of model to something other than id (ex: CustomId)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasKey(t => t.CustomId);
        }
        */

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TripContext>();

                context.Database.EnsureCreated();

                if (context.Trips.Any())
                {
                    return;
                }

                context.Trips.AddRange(new Trip[]
                {
                    new Trip
                    {
                        Id = 1,
                        Name = "Europa",
                        StartDate = new DateTime(2018, 3, 5),
                        EndDate = new DateTime(2018, 3, 8)
                    },
                    new Trip
                    {
                        Id = 2,
                        Name = "Vancouver",
                        StartDate = new DateTime(2019, 12, 6),
                        EndDate = new DateTime(2018, 12, 9)
                    }
                }
                );
                context.SaveChanges();
            }
        }
    }
}
