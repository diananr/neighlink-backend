﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191115033824_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Neighlink.Entity.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cantidad");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int?>("buildingId");

                    b.Property<int?>("paymentCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("buildingId");

                    b.HasIndex("paymentCategoryId");

                    b.ToTable("bills");
                });

            modelBuilder.Entity("Neighlink.Entity.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Names")
                        .HasMaxLength(50);

                    b.Property<int>("NumberOfHomes")
                        .HasColumnName("NumberOfHomes")
                        .HasMaxLength(4);

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("buildings");
                });

            modelBuilder.Entity("Neighlink.Entity.Condominium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoUrl");

                    b.Property<string>("SecretCode");

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int?>("billId");

                    b.Property<int?>("buildingId");

                    b.Property<int?>("newsId");

                    b.Property<int?>("paymentCategoryId");

                    b.Property<int?>("pollId");

                    b.Property<int?>("roleId");

                    b.HasKey("Id");

                    b.HasIndex("billId");

                    b.HasIndex("buildingId");

                    b.HasIndex("newsId");

                    b.HasIndex("paymentCategoryId");

                    b.HasIndex("pollId");

                    b.HasIndex("roleId");

                    b.ToTable("condominiums");
                });

            modelBuilder.Entity("Neighlink.Entity.Entity.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("Description");

                    b.Property<DateTimeOffset>("EndDate");

                    b.Property<DateTimeOffset>("StarDate");

                    b.Property<bool>("Status");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("polls");
                });

            modelBuilder.Entity("Neighlink.Entity.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTimeOffset>("Date");

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("Description");

                    b.Property<bool>("Status");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("news");
                });

            modelBuilder.Entity("Neighlink.Entity.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("Descripcion");

                    b.Property<string>("Name");

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("options");
                });

            modelBuilder.Entity("Neighlink.Entity.PaymentCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Descriptions")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Names")
                        .HasMaxLength(20);

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("paymentcategorys");
                });

            modelBuilder.Entity("Neighlink.Entity.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("Description");

                    b.Property<int>("NumberOfHomes");

                    b.Property<bool>("Status");

                    b.Property<int>("Type");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int?>("condominiumId");

                    b.HasKey("Id");

                    b.HasIndex("condominiumId");

                    b.ToTable("plans");
                });

            modelBuilder.Entity("Neighlink.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Descriptions")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Names")
                        .HasMaxLength(20);

                    b.Property<bool>("Status");

                    b.Property<int>("Type");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Neighlink.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<DateTime?>("DeleteAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PhotoUrl");

                    b.Property<byte[]>("Salt");

                    b.Property<byte[]>("SaltedAndHashedPassword");

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int?>("buildingId");

                    b.Property<int?>("roleId");

                    b.HasKey("Id");

                    b.HasIndex("buildingId");

                    b.HasIndex("roleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Neighlink.Entity.Bill", b =>
                {
                    b.HasOne("Neighlink.Entity.Building", "building")
                        .WithMany()
                        .HasForeignKey("buildingId");

                    b.HasOne("Neighlink.Entity.PaymentCategory", "paymentCategory")
                        .WithMany()
                        .HasForeignKey("paymentCategoryId");
                });

            modelBuilder.Entity("Neighlink.Entity.Condominium", b =>
                {
                    b.HasOne("Neighlink.Entity.Bill", "bill")
                        .WithMany()
                        .HasForeignKey("billId");

                    b.HasOne("Neighlink.Entity.Building", "building")
                        .WithMany()
                        .HasForeignKey("buildingId");

                    b.HasOne("Neighlink.Entity.News", "news")
                        .WithMany()
                        .HasForeignKey("newsId");

                    b.HasOne("Neighlink.Entity.PaymentCategory", "paymentCategory")
                        .WithMany()
                        .HasForeignKey("paymentCategoryId");

                    b.HasOne("Neighlink.Entity.Entity.Poll", "poll")
                        .WithMany()
                        .HasForeignKey("pollId");

                    b.HasOne("Neighlink.Entity.Role", "role")
                        .WithMany()
                        .HasForeignKey("roleId");
                });

            modelBuilder.Entity("Neighlink.Entity.Plan", b =>
                {
                    b.HasOne("Neighlink.Entity.Condominium", "condominium")
                        .WithMany()
                        .HasForeignKey("condominiumId");
                });

            modelBuilder.Entity("Neighlink.Entity.User", b =>
                {
                    b.HasOne("Neighlink.Entity.Building", "building")
                        .WithMany()
                        .HasForeignKey("buildingId");

                    b.HasOne("Neighlink.Entity.Role", "role")
                        .WithMany()
                        .HasForeignKey("roleId");
                });
#pragma warning restore 612, 618
        }
    }
}