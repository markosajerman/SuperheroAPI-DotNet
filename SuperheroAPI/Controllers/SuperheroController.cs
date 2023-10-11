using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperheroController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> Get()
        {
            return Ok(await _context.Superheroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> Get(int id)
        {
            var hero = await _context.Superheroes.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("Hero not found.");
            }
            return Ok(hero);
        }

        [HttpPost]

        public async Task<ActionResult<List<Superhero>>> AddHero(Superhero hero)
        {
            _context.Superheroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Superheroes.ToListAsync());

        }

        [HttpPut]

        public async Task<ActionResult<List<Superhero>>> UpdateHero(Superhero request)
        {
            var dbHero = await _context.Superheroes.FindAsync(request.Id);
            if (dbHero == null)
           
                return BadRequest("Hero not found.");      
          
            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;
            
            await _context.SaveChangesAsync();

            return Ok(await _context.Superheroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Superhero>>> Delete(int id)
        {
            var dbHero = await _context.Superheroes.FindAsync(id);
            if (dbHero == null)
            {
                return BadRequest("Hero not found.");
            }
            _context.Superheroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Superheroes.ToListAsync());
        }
    }
}
