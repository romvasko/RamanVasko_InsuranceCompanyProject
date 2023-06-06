using DatabaseSetupProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseSetupProject.Data {
    public class ApplicationDbContext : IdentityDbContext {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BankPayment> BankPayments { get; set; }
        public DbSet<BankPaymentPolicyOrder> bankPaymentPolicyOrders { get; set; }
        public DbSet<InsuranceCase> InsuranceCases { get; set; }
        public DbSet<Policies> Policies { get; set; } 
        public DbSet<PoliciesType> PoliciesTypes { get; set; }
        public DbSet<PoliciesOrder> PoliciesOrders { get; set; }
        public DbSet<PoliciesStatus> PoliciesStatuses { get; set; }
        //
        public DbSet<CarPolicyCondition> CarPolicyConditions { get; set; }
        //
        public DbSet<CarPolicyOrder> CarPolicyOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PoliciesStatus>().HasData(
               new PoliciesStatus[]
               {
                    new PoliciesStatus {Id = 1, StatusName = "InProced"},
                    new PoliciesStatus {Id = 2, StatusName = "Accepted"},
                    new PoliciesStatus {Id = 3, StatusName = "Declined"},
                    new PoliciesStatus {Id = 4, StatusName = "Paid"},
               });
            modelBuilder.Entity<PoliciesType>().HasData(
               new PoliciesType[]
               {
                    new PoliciesType {Id = 1, PoliciesTypeName = "Private"},
                    new PoliciesType {Id = 2, PoliciesTypeName = "Corporate"}
               });

            modelBuilder.Entity<Policies>().HasData(
               new Policies[]
               {
                    new Policies {Id = 1, PoliciesName = "Car insurance", PoliciesTypeId = 1,
                        BaseCost = 1000M, PoliciesDescription = "Car insurance"},
                    new Policies {Id = 2, PoliciesName = "Deposits insurance", PoliciesTypeId = 2,
                        BaseCost = 20000M, PoliciesDescription = "Deposits insurance"}
               });
                modelBuilder.Entity<PoliciesOrder>().HasData(
               new PoliciesOrder[]
               {
                    new PoliciesOrder {Id = 1000, UserId = "User1@user.com", PoliciesStatusId = 4, Cost = 48000,
                    PoliciesOrderDateTime = DateTime.Parse("2020-05-16T05:50:06"), PoliciesId = 2},
                    new PoliciesOrder {Id = 1001, UserId = "User2@user.com", PoliciesStatusId = 4, Cost = 62000,
                    PoliciesOrderDateTime = DateTime.Parse("2021-05-16T05:50:06"), PoliciesId = 2},
                    new PoliciesOrder {Id = 1002, UserId = "User3@user.com", PoliciesStatusId = 4, Cost = 150,
                    PoliciesOrderDateTime = DateTime.Parse("2022-05-16T05:50:06"), PoliciesId = 2},
                    new PoliciesOrder {Id = 1003, UserId = "User4@user.com", PoliciesStatusId = 4, Cost = 7894,
                    PoliciesOrderDateTime = DateTime.Parse("2021-05-16T05:50:06"), PoliciesId = 1},
                    new PoliciesOrder {Id = 1004, UserId = "User5@user.com", PoliciesStatusId = 4, Cost = 5555,
                    PoliciesOrderDateTime = DateTime.Parse("2023-05-16T05:50:06"), PoliciesId = 1},
                    new PoliciesOrder {Id = 1005, UserId = "User4@user.com", PoliciesStatusId = 4, Cost = 7777,
                    PoliciesOrderDateTime = DateTime.Parse("2023-05-16T05:50:06"), PoliciesId = 2},
                    new PoliciesOrder {Id = 1006, UserId = "User3@user.com", PoliciesStatusId = 4, Cost = 6548,
                    PoliciesOrderDateTime = DateTime.Parse("2020-05-16T05:50:06"), PoliciesId = 2},
                    new PoliciesOrder {Id = 1007, UserId = "User2@user.com", PoliciesStatusId = 4, Cost = 1254,
                    PoliciesOrderDateTime = DateTime.Parse("2020-05-16T05:50:06"), PoliciesId = 1},
               });
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
    }

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
        }
    }
}