using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using local = Book_Tracking_Application_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Book_Tracking_Application_Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Book_Tracking_Application_Models;

namespace Book_Tracking_Application_App.Pages
{
    public class AddBookModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BookCatalogue _db;

        [FromForm]
        public Book book { get; set; }
        public List<Book> Books { get; private set; }

        [FromForm]
        public Category category { get; set; }
        public List<Category> Categories { get; private set; }

        [FromForm]
        public CategoryType categoryType { get; set; }
        public List<CategoryType> CategoryTypes { get;  set; }

        public AddBookModel(ILogger<IndexModel> logger, BookCatalogue db)
        {
            _logger = logger;
            _db = db;
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
                _db.Add<Book>(book);
                _db.Add<Category>(category);
                _db.Add<CategoryType>(categoryType);
                _db.SaveChangesAsync();
            
            return RedirectToPage();
        }
    }
}
