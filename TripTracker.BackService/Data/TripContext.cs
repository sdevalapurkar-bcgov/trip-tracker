using Microsoft.EntityFrameworkCore;

namespace TripTracker.BackService.Data
{
    public class TripContext:DbContext //register a db context
    {
        public DbSet<Backservice.Models.Trip> Trips { get; set; }

        /*
         * used to override convention if you wish to rename the key property of model to something other than id (ex: CustomId)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasKey(t => t.CustomId);
        }
        */
    }
}
