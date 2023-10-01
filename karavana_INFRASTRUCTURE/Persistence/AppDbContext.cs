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
        public DbSet<CaravanImage> CaravanImages { get; set; }
        public DbSet<CaravanRentOffer> CaravanRentOffers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }

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

                entity.HasMany(a => a.CaravanRentOffers)
                .WithOne(u => u.Caravan)
                .HasForeignKey(x => x.CaravanId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caravan_CaravanRentOffers");

                entity.HasMany(a => a.Images)
                .WithOne(u => u.Caravan)
                .HasForeignKey(x => x.CaravanId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Caravan_Images");
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

            modelBuilder.Entity<CaravanRentOffer>(entity =>
            {
                entity.ToTable(nameof(CaravanRentOffer));
                entity.HasKey(x => x.Id);

                entity.HasMany(a => a.Favourites)
                .WithOne(u => u.CaravanRentOffer)
                .HasForeignKey(x => x.CaravanRentOfferId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CaravanRentOffer_Favourites");

                entity.HasMany(a => a.Ratings)
                .WithOne(u => u.CaravanRentOffer)
                .HasForeignKey(x => x.CaravanRentOfferId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CaravanRentOffer_Ratings");

            });

            modelBuilder.Entity<Favourite>(entity =>
            {
                entity.ToTable(nameof(Favourite));
                entity.HasKey(x => x.Id);

                entity.HasOne(a => a.CaravanRentOffer)
                .WithMany(u => u.Favourites)
                .HasForeignKey(x => x.CaravanRentOfferId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favourite_CaravanRentOffer");

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

                entity.HasOne(a => a.CaravanRentOffer)
                .WithMany(u => u.Ratings)
                .HasForeignKey(x => x.CaravanRentOfferId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_CaravanRentOffer");

                entity.HasOne(a => a.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(x => x.UserId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_User");
            });

            modelBuilder.Entity<CaravanImage>(entity =>
            {
                entity.ToTable(nameof(CaravanImage));
                entity.HasKey(x => x.Id);

                entity.HasOne(a => a.Caravan)
                .WithMany(u => u.Images)
                .HasForeignKey(x => x.CaravanId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CaravanImage_Caravan");
            });


        }
    }
}
