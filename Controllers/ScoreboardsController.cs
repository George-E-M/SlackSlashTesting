using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScoreboardsAPI.Models;

namespace ScoreboardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreboardsController : ControllerBase
    {
        private readonly ScoreboardsContext _context;

        public ScoreboardsController(ScoreboardsContext context)
        {
            _context = context;

            if (_context.ScoreboardsItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.ScoreboardsItems.Add(new ScoreboardsItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Scoreboards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScoreboardsItem>>> GetScoreboardsItems()
        {
            return await _context.ScoreboardsItems.ToListAsync();
        }

        // GET: api/Scoreboards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScoreboardsItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.ScoreboardsItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/Scoreboards
        [HttpPost]
        public async Task<ActionResult<ScoreboardsItem>> PostScoreboardsItem(ScoreboardsItem scoreboardsItem)
        {
            _context.ScoreboardsItems.Add(scoreboardsItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScoreboardsItem", new { id = scoreboardsItem.Id }, scoreboardsItem);
        }

        // PUT: api/Scoreboards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScoreboardsItem(long id, ScoreboardsItem scoreboardsItem)
        {
            if (id != scoreboardsItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(scoreboardsItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Scoreboards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ScoreboardsItem>> DeleteScoreboardsItem(long id)
        {
            var scoreboardsItem = await _context.ScoreboardsItems.FindAsync(id);
            if (scoreboardsItem == null)
            {
                return NotFound();
            }

            _context.ScoreboardsItems.Remove(scoreboardsItem);
            await _context.SaveChangesAsync();

            return scoreboardsItem;
        }

        // GET: api/Scoreboards/rank
        [HttpGet]
        [Route("rank")]
        [Produces("application/json")]
        public string GetByRank([FromQuery] SlashCommandPayload payload)
        {
            //string rank = payload.text;

            //var user = _context.ScoreboardsItems.Where(u => u.Rank == rank);
            //return user.First().Name
            return "Working";
        }
    }
}