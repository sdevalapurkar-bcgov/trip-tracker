using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripTracker.Backservice.Models;
using TripTracker.BackService.Data;

namespace TripTracker.BackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        TripContext _context; //gets instantiated per request (context of db but not the db itself) "short-lived context"

        public TripsController(TripContext context)
        {
            _context = context;
            //to not track context (for materializing objects)
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // GET api/Trips
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var trips = await _context.Trips.AsNoTracking().ToListAsync();
            return Ok(trips);
        }

        // GET api/Trips/5
        [HttpGet("{id}")]
        public Trip Get(int id)
        {
            return _context.Trips.Find(id);
        }

        // POST api/Trips
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Trip value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.Trips.Add(value);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT api/Trips/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Trip value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.Trips.Find(id) == null)
            {
                return NotFound();
            }

            //need to explicitly be careful about null values
            _context.Trips.Update(value);
            await _context.SaveChangesAsync();

            return Ok();
        }
        
        // DELETE api/Trips/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var myTrip = _context.Trips.Find(id);

            if (myTrip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(myTrip);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
