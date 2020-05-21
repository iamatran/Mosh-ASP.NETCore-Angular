using Microsoft.EntityFrameworkCore;
using Mosh_Guided_Tutorial.Models;

namespace Mosh_Guided_Tutorial.Persistence
{
    public class VegaDbContext : DbContext
    {

        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {

        }

        // When adding a Migration, this is how the models are recognized by the migration. If not here, the migration will appear empty
        // Notice that we only have Make here and not Model. This is bc Make has a relationship setup with Model, so the migration will implicitly find Model
            // !!! You only add DbSet for Models IF you need to directly query this separately!!!
        public DbSet<Make> Makes { get; set; }

    }
}