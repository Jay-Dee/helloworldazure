using Microsoft.EntityFrameworkCore;

namespace helloazure.Models {
    public class PersonContext : DbContext {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)   {
    }

    public DbSet<Person> Persons { get; set; }
    }
}    
