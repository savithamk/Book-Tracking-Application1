using System;
using Book_Tracking_Application_Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Tracking_Application_Context
{
    public class BookCatalogue : DbContext
    {
        public BookCatalogue(DbContextOptions<BookCatalogue> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> categoryTypes { get; set; }

    }
}
