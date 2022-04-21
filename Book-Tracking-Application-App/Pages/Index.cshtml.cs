using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using local = Book_Tracking_Application_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Schema.NET;
using Book = Schema.NET.Book;
using Book_Tracking_Application_Context;
using Book_Tracking_Application_Models;

namespace Book_Tracking_Application_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BookCatalogue _db;

        public Thing JSONLD { get { return Book.GetJson(); } }

        public local.Book Book { get; set; } = new local.Book();

        [FromForm]
        public local.Book book { get; set; }
        public List<local.Book> Books { get; private set; }

        [FromForm]
        public Category category { get; set; }
        public List<Category> Categories { get; private set; }

        [FromForm]
        public CategoryType categoryType { get; set; }
        public List<CategoryType> CategoryTypes { get; set; }

        public IndexModel(ILogger<IndexModel> logger, BookCatalogue db)
        {
            _logger = logger;
            _db = db;
            Book.ISBN = "isbn";
            Book.Title = "New Book";
            Book.Author = "savitha";
        }

        public void OnGet()
        {
            var bookQuery = _db.Books.Select(book => book);
            Books = bookQuery.ToList();

        }

        public RedirectToPageResult OnPost()
        {
            if (categoryType.Type.Equals("ADFICN"))
            {
                categoryType.Name = "Adult Fiction";
                category.NameToken = "ADFICN";
                category.Description = "Fiction";

            }
            else if (categoryType.Type.Equals("CHFICN"))
            {
                categoryType.Name = "Children's Fiction";
                category.NameToken = "CHFICN";
                category.Description = "Fiction";
            }
            else if (categoryType.Type.Equals("ATBGY"))
            {
                categoryType.Name = "Autobiography";
                category.NameToken = "ATBGY";
                category.Description = "Non-Fiction";
            }
            else if (categoryType.Type.Equals("HTRY"))
            {
                categoryType.Name = "History";
                category.NameToken = "HTRY";
                category.Description = "Non-Fiction";
            }
            else if (categoryType.Type.Equals("PHSY"))
            {
                categoryType.Name = "Philosophy";
                category.NameToken = "PHSY";
                category.Description = "Non-Fiction";
            }
            else if (categoryType.Type.Equals("SCI"))
            {
                categoryType.Name = "Science";
                category.NameToken = "SCI";
                category.Description = "Non-Fiction";
            }
            else if (categoryType.Type.Equals("WTPR"))
            {
                categoryType.Name = "Whitepaper";
                category.NameToken = "WTPR";
                category.Description = "Non-Fiction";
            }

            book.NameToken = category.NameToken;
            category.Type = categoryType.Type;
            _db.Add<local.Book>(book);
            _db.Add<Category>(category);
            _db.Add<CategoryType>(categoryType);
            _db.SaveChangesAsync();

            return RedirectToPage();
        }

    }
}
