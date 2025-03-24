using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameApi.Controllers.Data;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {
        private readonly VideoGameDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideogame()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);

            if(game is null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideogame(VideoGame newGame)
        {
            if (newGame is null) return BadRequest();

            _context.VideoGames.Add(newGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateVideogame(int id, VideoGame updateGame)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null) return NotFound();

            game.Title = updateGame.Title;
            game.Platform = updateGame.Platform;
            game.Developer = updateGame.Developer;
            game.Publisher = updateGame.Publisher;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteVideogame(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null) return NotFound();

            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
