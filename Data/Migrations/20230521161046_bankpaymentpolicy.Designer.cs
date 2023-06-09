﻿// <auto-generated />
using System;
using DatabaseSetupProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230521161046_bankpaymentpolicy")]
    partial class bankpaymentpolicy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DatabaseSetupProject.Models.BankPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BankPayments");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.BankPaymentPolicyOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BankPaymentId")
                        .HasColumnType("int");

                    b.Property<int>("PoliciesOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankPaymentId");

                    b.HasIndex("PoliciesOrderId");

                    b.ToTable("bankPaymentPolicyOrders");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.CarPolicyCondition", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("DriverAge")
                        .HasColumnType("int");

                    b.Property<bool>("IsHadAccident")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("CarPolicyConditions");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.CarPolicyOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarPolicyConditionId")
                        .HasColumnType("int");

                    b.Property<int>("PoliciesOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarPolicyConditionId");

                    b.HasIndex("PoliciesOrderId");

                    b.ToTable("CarPolicyOrder");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartWorking")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.InsuranceCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("InsuranceCaseDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PoliciesOrderId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PoliciesOrderId");

                    b.ToTable("InsuranceCases");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.Policies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("BaseCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PoliciesDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoliciesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PoliciesTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PoliciesTypeId");

                    b.ToTable("Policies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseCost = 1000m,
                            PoliciesDescription = "Страхование автомобилей",
                            PoliciesName = "Автомобильное",
                            PoliciesTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            BaseCost = 1000m,
                            PoliciesDescription = "Страхование вкладов",
                            PoliciesName = "Вклады",
                            PoliciesTypeId = 2
                        });
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.PoliciesOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BankPaymentsId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("PoliciesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PoliciesOrderDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PoliciesStatusId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BankPaymentsId");

                    b.HasIndex("PoliciesId");

                    b.HasIndex("PoliciesStatusId");

                    b.ToTable("PoliciesOrders");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.PoliciesStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PoliciesStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "InProced"
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "Accepted"
                        },
                        new
                        {
                            Id = 3,
                            StatusName = "Declined"
                        },
                        new
                        {
                            Id = 4,
                            StatusName = "Paid"
                        });
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.PoliciesType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PoliciesTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PoliciesTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PoliciesTypeName = "Частные"
                        },
                        new
                        {
                            Id = 2,
                            PoliciesTypeName = "Корпоративные"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.UserData", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasDiscriminator().HasValue("UserData");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.BankPaymentPolicyOrder", b =>
                {
                    b.HasOne("DatabaseSetupProject.Models.BankPayment", "CarPolicyCondition")
                        .WithMany("bankPaymentPolicyOrders")
                        .HasForeignKey("BankPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseSetupProject.Models.PoliciesOrder", "PoliciesOrder")
                        .WithMany("bankPaymentPolicyOrders")
                        .HasForeignKey("PoliciesOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarPolicyCondition");

                    b.Navigation("PoliciesOrder");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.CarPolicyOrder", b =>
                {
                    b.HasOne("DatabaseSetupProject.Models.CarPolicyCondition", "CarPolicyCondition")
                        .WithMany("CarPolicyOrders")
                        .HasForeignKey("CarPolicyConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseSetupProject.Models.PoliciesOrder", "PoliciesOrder")
                        .WithMany("CarPolicyOrders")
                        .HasForeignKey("PoliciesOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarPolicyCondition");

                    b.Navigation("PoliciesOrder");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.Employee", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.InsuranceCase", b =>
                {
                    b.HasOne("DatabaseSetupProject.Models.PoliciesOrder", null)
                        .WithMany("InsuranceCases")
                        .HasForeignKey("PoliciesOrderId");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.Policies", b =>
                {
                    b.HasOne("DatabaseSetupProject.Models.PoliciesType", "PoliciesType")
                        .WithMany("Policies")
                        .HasForeignKey("PoliciesTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PoliciesType");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.PoliciesOrder", b =>
                {
                    b.HasOne("DatabaseSetupProject.Models.BankPayment", "BankPayments")
                        .WithMany()
                        .HasForeignKey("BankPaymentsId");

                    b.HasOne("DatabaseSetupProject.Models.Policies", "Policies")
                        .WithMany()
                        .HasForeignKey("PoliciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseSetupProject.Models.PoliciesStatus", "PoliciesStatus")
                        .WithMany("PoliciesOrders")
                        .HasForeignKey("PoliciesStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankPayments");

                    b.Navigation("Policies");

                    b.Navigation("PoliciesStatus");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.BankPayment", b =>
                {
                    b.Navigation("bankPaymentPolicyOrders");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.CarPolicyCondition", b =>
                {
                    b.Navigation("CarPolicyOrders");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.PoliciesOrder", b =>
                {
                    b.Navigation("CarPolicyOrders");

                    b.Navigation("InsuranceCases");

                    b.Navigation("bankPaymentPolicyOrders");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.PoliciesStatus", b =>
                {
                    b.Navigation("PoliciesOrders");
                });

            modelBuilder.Entity("DatabaseSetupProject.Models.PoliciesType", b =>
                {
                    b.Navigation("Policies");
                });
#pragma warning restore 612, 618
        }
    }
}
