using System;
using System.Collections.Generic;
using System.Linq;
namespace TripTracker.Backservice.Models
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip>
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
        };

        public List<Trip> Get()
        {
            return MyTrips;
        }

        public Trip Get(int id)
        {
            return MyTrips.First(t => t.Id == id);
        }

        public void Add(Trip newTrip)
        {
            MyTrips.Add(newTrip);
        }

        public void Update(Trip tripToUpdate)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == tripToUpdate.Id));
            Add(tripToUpdate);
        }

        public void Remove(int id)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == id));
        }
    }
}