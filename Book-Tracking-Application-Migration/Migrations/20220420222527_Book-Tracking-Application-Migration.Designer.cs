﻿// <auto-generated />
using Book_Tracking_Application_Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Book_Tracking_Application_Migration.Migrations
{
    [DbContext(typeof(BookCatalogue))]
    [Migration("20220420222527_Book-Tracking-Application-Migration")]
    partial class BookTrackingApplicationMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("Book_Tracking_Application_Models.Book", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryNameToken")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameToken")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ISBN");

                    b.HasIndex("CategoryNameToken");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Book_Tracking_Application_Models.Category", b =>
                {
                    b.Property<string>("NameToken")
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryTypeType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("NameToken");

                    b.HasIndex("CategoryTypeType");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Book_Tracking_Application_Models.CategoryType", b =>
                {
                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Type");

                    b.ToTable("categoryTypes");
                });

            modelBuilder.Entity("Book_Tracking_Application_Models.Book", b =>
                {
                    b.HasOne("Book_Tracking_Application_Models.Category", null)
                        .WithMany("Books")
                        .HasForeignKey("CategoryNameToken");
                });

            modelBuilder.Entity("Book_Tracking_Application_Models.Category", b =>
                {
                    b.HasOne("Book_Tracking_Application_Models.CategoryType", null)
                        .WithMany("Categories")
                        .HasForeignKey("CategoryTypeType");
                });

            modelBuilder.Entity("Book_Tracking_Application_Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Book_Tracking_Application_Models.CategoryType", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
