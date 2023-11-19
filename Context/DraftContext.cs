using Microsoft.EntityFrameworkCore;

namespace draftAPI.Context
{
    using draftAPI.Model;
    using Microsoft.EntityFrameworkCore;

    public class DraftContext
        : DbContext
    {
        public DraftContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<ContentInfo> Contents { get; set; }
    }
}
