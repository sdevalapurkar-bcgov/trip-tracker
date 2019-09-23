using System;

namespace TripTracker.Backservice.Models
{
    public class Segment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset StartDateTime { get; set; }

        public DateTimeOffset EndDateTime { get; set; }

        public string Description { get; set; }

        public int tripId { get; set; }
    }
}
