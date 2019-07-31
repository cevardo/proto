﻿// <auto-generated />
using Embily.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Embily.Models.Migrations
{
    [DbContext(typeof(EmbilyDbContext))]
    [Migration("20180722153327_affiliate-update1")]
    partial class affiliateupdate1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("Relational:Sequence:.TransactionNumbers", "'TransactionNumbers', '', '10000', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.UserNumbers", "'UserNumbers', '', '1000001009', '1', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Embily.Models.Account", b =>
                {
                    b.Property<string>("AccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.Property<string>("AccountNumber")
                        .IsRequired();

                    b.Property<string>("AccountStatusString")
                        .IsRequired()
                        .HasColumnName("AccountStatus");

                    b.Property<string>("AccountTypeString")
                        .IsRequired()
                        .HasColumnName("AccountType");

                    b.Property<double>("Balance");

                    b.Property<string>("CurrencyCodeString")
                        .IsRequired()
                        .HasColumnName("CurrencyCode");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<string>("ProviderAccountNumber")
                        .IsRequired();

                    b.Property<string>("ProviderNameString")
                        .IsRequired()
                        .HasColumnName("ProviderName");

                    b.Property<string>("ProviderUserId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("AccountId");

                    b.HasIndex("AccountNumber")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Embily.Models.Address", b =>
                {
                    b.Property<string>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1")
                        .IsRequired();

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("PostalCode")
                        .IsRequired();

                    b.Property<string>("Province");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Embily.Models.AffiliateEmail", b =>
                {
                    b.Property<string>("AffiliateEmailId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email");

                    b.Property<bool>("HasRegistred");

                    b.Property<bool>("IsInvite");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("TokenUsed");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("AffiliateEmailId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("AffiliateEmails");
                });

            modelBuilder.Entity("Embily.Models.AffiliateToken", b =>
                {
                    b.Property<string>("AffiliateTokenId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Counter");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsSuspended");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Token")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("AffiliateTokenId");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("AffiliateTokens");
                });

            modelBuilder.Entity("Embily.Models.Application", b =>
                {
                    b.Property<string>("ApplicationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountTypeString")
                        .IsRequired()
                        .HasColumnName("AccountType");

                    b.Property<string>("AddressId");

                    b.Property<string>("ApplicationNumber")
                        .IsRequired();

                    b.Property<string>("Comments");

                    b.Property<string>("CurrencyCodeString")
                        .IsRequired()
                        .HasColumnName("CurrencyCode");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("GenderString")
                        .HasColumnName("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("MaritalStatusString")
                        .HasColumnName("MaritalStatus");

                    b.Property<string>("Nationality");

                    b.Property<string>("Phone");

                    b.Property<string>("ProviderAccountNumber");

                    b.Property<string>("ProviderNameString")
                        .IsRequired()
                        .HasColumnName("ProviderName");

                    b.Property<string>("ProviderUserId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ShippingAddressId");

                    b.Property<string>("ShippingCarrier");

                    b.Property<string>("ShippingTrackingNum");

                    b.Property<string>("StatusString")
                        .IsRequired()
                        .HasColumnName("Status");

                    b.Property<string>("TitleString")
                        .HasColumnName("Title");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("ApplicationId");

                    b.HasIndex("AddressId");

                    b.HasIndex("ApplicationNumber")
                        .IsUnique();

                    b.HasIndex("ShippingAddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Embily.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateLastAccessed");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<long>("UserNumber")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR UserNumbers");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserNumber")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Embily.Models.CardOrder", b =>
                {
                    b.Property<string>("CardOrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationId")
                        .IsRequired();

                    b.Property<string>("Comments");

                    b.Property<string>("CryptoAddress");

                    b.Property<string>("CryptoAddressLink");

                    b.Property<string>("CryptoAddressQRCode");

                    b.Property<double>("CryptoAmount");

                    b.Property<string>("CryptoCurrencyCodeString")
                        .IsRequired()
                        .HasColumnName("CryptoCurrencyCode");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModified");

                    b.Property<double>("PurchaseAmount");

                    b.Property<string>("PurchaseCurrencyCodeString")
                        .IsRequired()
                        .HasColumnName("PurchaseCurrencyCode");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("StatusString")
                        .IsRequired()
                        .HasColumnName("Status");

                    b.HasKey("CardOrderId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("CardOrders");
                });

            modelBuilder.Entity("Embily.Models.Configuration", b =>
                {
                    b.Property<string>("ConfigurationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModified");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ConfigurationId");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("Embily.Models.CryptoAddress", b =>
                {
                    b.Property<string>("CryptoAddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId")
                        .IsRequired();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("CurrencyCodeString")
                        .IsRequired()
                        .HasColumnName("CurrencyCode");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModified");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("CryptoAddressId");

                    b.HasIndex("AccountId");

                    b.ToTable("CryptoAddresses");
                });

            modelBuilder.Entity("Embily.Models.Document", b =>
                {
                    b.Property<string>("DocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationId")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("DocumentTypeString")
                        .HasColumnName("DocumentType");

                    b.Property<string>("FileType")
                        .IsRequired();

                    b.Property<byte[]>("Image")
                        .IsRequired();

                    b.Property<int>("Order");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("DocumentId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Embily.Models.Transaction", b =>
                {
                    b.Property<string>("TransactionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountId")
                        .IsRequired();

                    b.Property<string>("Comments");

                    b.Property<string>("CryptoAddress")
                        .IsRequired();

                    b.Property<string>("CryptoProviderString")
                        .IsRequired()
                        .HasColumnName("CryptoProvider");

                    b.Property<string>("CryptoTxnId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("DestinationAccountId");

                    b.Property<double>("DestinationAmount");

                    b.Property<string>("DestinationCurrencyCodeString")
                        .IsRequired()
                        .HasColumnName("DestinationCurrencyCode");

                    b.Property<double>("ExchangeFee");

                    b.Property<bool>("IsAmountKnown");

                    b.Property<double>("OriginalAmount");

                    b.Property<string>("OriginalCurrencyCodeString")
                        .IsRequired()
                        .HasColumnName("OriginalCurrencyCode");

                    b.Property<double>("PlatformFee");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("SourceAccountId");

                    b.Property<string>("StatusString")
                        .IsRequired()
                        .HasColumnName("Status");

                    b.Property<string>("TransactionNumber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR TransactionNumbers");

                    b.Property<string>("TxnCodeString")
                        .IsRequired()
                        .HasColumnName("TxnCode");

                    b.Property<string>("TxnTypeString")
                        .IsRequired()
                        .HasColumnName("TxnType");

                    b.HasKey("TransactionId");

                    b.HasIndex("AccountId");

                    b.HasIndex("TransactionNumber")
                        .IsUnique();

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictApplication", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientId");

                    b.Property<string>("ClientSecret");

                    b.Property<string>("DisplayName");

                    b.Property<string>("LogoutRedirectUri");

                    b.Property<string>("RedirectUri");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique()
                        .HasFilter("[ClientId] IS NOT NULL");

                    b.ToTable("OpenIddictApplications");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictAuthorization", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationId");

                    b.Property<string>("Scope");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("OpenIddictAuthorizations");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictScope", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("OpenIddictScopes");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictToken", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationId");

                    b.Property<string>("AuthorizationId");

                    b.Property<string>("Subject");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("AuthorizationId");

                    b.ToTable("OpenIddictTokens");
                });

            modelBuilder.Entity("Embily.Models.Account", b =>
                {
                    b.HasOne("Embily.Models.ApplicationUser", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Embily.Models.Address", b =>
                {
                    b.HasOne("Embily.Models.ApplicationUser", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Embily.Models.AffiliateEmail", b =>
                {
                    b.HasOne("Embily.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Embily.Models.AffiliateToken", b =>
                {
                    b.HasOne("Embily.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Embily.Models.Application", b =>
                {
                    b.HasOne("Embily.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Embily.Models.Address", "ShippingAddress")
                        .WithMany()
                        .HasForeignKey("ShippingAddressId");

                    b.HasOne("Embily.Models.ApplicationUser", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Embily.Models.CardOrder", b =>
                {
                    b.HasOne("Embily.Models.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Embily.Models.CryptoAddress", b =>
                {
                    b.HasOne("Embily.Models.Account", "Account")
                        .WithMany("CryptoAddreses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Embily.Models.Document", b =>
                {
                    b.HasOne("Embily.Models.Application", "Application")
                        .WithMany("Documents")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Embily.Models.Transaction", b =>
                {
                    b.HasOne("Embily.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Embily.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Embily.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Embily.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Embily.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictAuthorization", b =>
                {
                    b.HasOne("OpenIddict.Models.OpenIddictApplication", "Application")
                        .WithMany("Authorizations")
                        .HasForeignKey("ApplicationId");
                });

            modelBuilder.Entity("OpenIddict.Models.OpenIddictToken", b =>
                {
                    b.HasOne("OpenIddict.Models.OpenIddictApplication", "Application")
                        .WithMany("Tokens")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("OpenIddict.Models.OpenIddictAuthorization", "Authorization")
                        .WithMany("Tokens")
                        .HasForeignKey("AuthorizationId");
                });
#pragma warning restore 612, 618
        }
    }
}
