using karavana_DOMAIN.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace karavana_INFRASTRUCTURE.Persistence
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Caravan> Caravans { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Caravan>(entity =>
            {
                entity.ToTable(nameof(Caravan));

                entity.HasOne(a => a.Company)
                .WithMany(u => u.Caravans)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caravan_Company");

                entity.HasOne(a => a.Company)
                .WithMany(u => u.Caravans)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caravan_Company");

                entity.HasOne(a => a.City)
                .WithMany(u => u.Caravans)
                .HasForeignKey(x => x.CityId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caravan_City");

                entity.HasOne(a => a.District)
                .WithMany(u => u.Caravans)
                .HasForeignKey(x => x.DistrictId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caravan_District");

                entity.HasMany(a => a.ActiveCaravanPlaces)
                .WithOne(u => u.Caravan)
                .HasForeignKey(x => x.CaravanId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caravan_ActiveCaravanPlaces");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(nameof(User));

                entity.HasMany(a => a.Favourites)
                .WithOne(u => u.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Favourites");

                entity.HasMany(a => a.Ratings)
                .WithOne(u => u.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Ratings");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable(nameof(Company));

                entity.HasMany(a => a.Caravans)
                .WithOne(u => u.Company)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Company_Caravan");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable(nameof(City));
                entity.HasKey(x => x.Id);

                entity.HasMany(a => a.Districts)
                .WithOne(u => u.City)
                .HasForeignKey(x => x.CityId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_District");

                entity.HasMany(a => a.Caravans)
                .WithOne(u => u.City)
                .HasForeignKey(x => x.CityId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Caravans");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable(nameof(District));
                entity.HasKey(x => x.Id);

                entity.HasOne(a => a.City)
                .WithMany(u => u.Districts)
                .HasForeignKey(x => x.CityId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_District_City");

                entity.HasMany(a => a.Caravans)
                .WithOne(u => u.District)
                .HasForeignKey(x => x.DistrictId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_District_Caravans");
            });

            modelBuilder.Entity<ActiveCaravanPlace>(entity =>
            {
                entity.ToTable(nameof(ActiveCaravanPlace));
                entity.HasKey(x => x.Id);

                entity.HasMany(a => a.Favourites)
                .WithOne(u => u.ActiveCaravanPlace)
                .HasForeignKey(x => x.ActiveCaravanPlaceId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActiveCaravanPlace_Favourites");

                entity.HasMany(a => a.Ratings)
                .WithOne(u => u.ActiveCaravanPlace)
                .HasForeignKey(x => x.ActiveCaravanPlaceId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActiveCaravanPlace_Ratings");

            });

            modelBuilder.Entity<Favourite>(entity =>
            {
                entity.ToTable(nameof(Favourite));
                entity.HasKey(x => x.Id);

                entity.HasOne(a => a.ActiveCaravanPlace)
                .WithMany(u => u.Favourites)
                .HasForeignKey(x => x.ActiveCaravanPlaceId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favourite_ActiveCaravanPlace");

                entity.HasOne(a => a.User)
                .WithMany(u => u.Favourites)
                .HasForeignKey(x => x.UserId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favourite_User");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable(nameof(Rating));
                entity.HasKey(x => x.Id);

                entity.HasOne(a => a.ActiveCaravanPlace)
                .WithMany(u => u.Ratings)
                .HasForeignKey(x => x.ActiveCaravanPlaceId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_ActiveCaravanPlace");

                entity.HasOne(a => a.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(x => x.UserId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_User");
            });


        }
    }
}
