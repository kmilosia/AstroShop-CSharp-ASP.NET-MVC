﻿// <auto-generated />
using System;
using AstroShop.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AstroShop.Data.Migrations
{
    [DbContext(typeof(AstroShopContext))]
    [Migration("20230520094518_M2")]
    partial class M2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AstroShop.Data.Data.CMS.Blog", b =>
                {
                    b.Property<int>("IDBlog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDBlog"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Heading")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IDBlogType")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LinkTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDBlog");

                    b.HasIndex("IDBlogType");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("AstroShop.Data.Data.CMS.BlogType", b =>
                {
                    b.Property<int>("IDBlogType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDBlogType"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDBlogType");

                    b.ToTable("BlogType");
                });

            modelBuilder.Entity("AstroShop.Data.Data.CMS.ContactLinks", b =>
                {
                    b.Property<int>("IDContactLinks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDContactLinks"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("DisplayPosition")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URLAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("IDContactLinks");

                    b.ToTable("ContactLinks");
                });

            modelBuilder.Entity("AstroShop.Data.Data.CMS.FooterLinks", b =>
                {
                    b.Property<int>("IDFooterLinks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDFooterLinks"), 1L, 1);

                    b.Property<int>("DisplayPosition")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LinkTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("IDFooterLinks");

                    b.ToTable("FooterLinks");
                });

            modelBuilder.Entity("AstroShop.Data.Data.CMS.News", b =>
                {
                    b.Property<int>("IDNews")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDNews"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Heading")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LinkTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDNews");

                    b.ToTable("News");
                });

            modelBuilder.Entity("AstroShop.Data.Data.CMS.Page", b =>
                {
                    b.Property<int>("IDPage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDPage"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("DisplayPosition")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LinkTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDPage");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("AstroShop.Data.Data.CMS.ProductsLinks", b =>
                {
                    b.Property<int>("IDProductsLinks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDProductsLinks"), 1L, 1);

                    b.Property<int>("DisplayPosition")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LinkTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("IDProductsLinks");

                    b.ToTable("ProductsLinks");
                });

            modelBuilder.Entity("AstroShop.Data.Data.CMS.SocialLinks", b =>
                {
                    b.Property<int>("IDSocialLinks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDSocialLinks"), 1L, 1);

                    b.Property<int>("DisplayPosition")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URLAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("IDSocialLinks");

                    b.ToTable("SocialLinks");
                });

            modelBuilder.Entity("AstroShop.Data.Data.Shop.Product", b =>
                {
                    b.Property<int>("IDProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDProduct"), 1L, 1);

                    b.Property<DateTime>("AddingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IDType")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Specifications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDProduct");

                    b.HasIndex("IDType");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("AstroShop.Data.Data.Shop.Type", b =>
                {
                    b.Property<int>("IDType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDType"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDType");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("AstroShop.Data.Data.CMS.Blog", b =>
                {
                    b.HasOne("AstroShop.Data.Data.CMS.BlogType", "BlogType")
                        .WithMany()
                        .HasForeignKey("IDBlogType");

                    b.Navigation("BlogType");
                });

            modelBuilder.Entity("AstroShop.Data.Data.Shop.Product", b =>
                {
                    b.HasOne("AstroShop.Data.Data.Shop.Type", "Type")
                        .WithMany()
                        .HasForeignKey("IDType");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
