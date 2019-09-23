using System;
using System.ComponentModel.DataAnnotations;

namespace TripTracker.Backservice.Models
{
    public class Trip
    {
        [Key] //data annotations for entity framework
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
