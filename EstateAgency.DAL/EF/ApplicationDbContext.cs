using EstateAgency.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EstateAgency.DAL.EF
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ApartmentOwner> ApartmentOwners { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<SaleAnnouncement> SaleAnnouncements { get; set; }
        public DbSet<RentAnnouncement> RentAnnouncements { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>()
                .HasOne(a => a.Apartment)
                .WithMany(a => a.Announcements)
                .HasForeignKey(a => a.ApartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            DatabaseSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
