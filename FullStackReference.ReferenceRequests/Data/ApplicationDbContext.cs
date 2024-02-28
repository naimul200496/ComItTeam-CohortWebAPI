using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullStackReference.ReferenceRequest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ReferenceRequest> ReferenceRequest { get; set; }

        // Add other DbSet properties for your entities if needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReferenceRequest>().HasKey(r => r.ReferenceRequestId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
