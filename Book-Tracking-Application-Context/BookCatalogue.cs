using System;
using Microsoft.EntityFrameworkCore;

namespace Book_Tracking_Application_Context
{
    public class BookCatalogue : DbContext
    {
        public BookCatalogue(DbContextOptions<BookCatalogue> options) : base(options) { }
        public DbSet<BookCatalogue> BookCatalogues { get; set; }

    }
}
