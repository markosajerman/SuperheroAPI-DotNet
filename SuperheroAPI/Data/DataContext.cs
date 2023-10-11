using Microsoft.EntityFrameworkCore;

namespace SuperheroAPI.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Superhero> Superheroes { get; set; }
    }
}
