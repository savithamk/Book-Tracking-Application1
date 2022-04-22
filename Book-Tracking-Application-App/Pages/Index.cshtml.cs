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
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public List<SelectListItem> CategorySelectionItems = new List<SelectListItem>();

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
            Books = new List<local.Book>();
            Categories = new List<Category>();
            var categoriesQuery = _db.Categories.Select(category => category);
            var bookQuery = _db.Books.Select(category => category);
            Categories = categoriesQuery.ToList();
            foreach (Category type in Categories)
            {
                SelectListItem item = new SelectListItem(type.Description, type.NameToken);
                CategorySelectionItems.Add(item);
            }
            foreach (local.Book book in bookQuery.ToList())
            {
                var typeDescription = Books.Find(category => category.NameToken.Equals(category.NameToken));
                if (null != category)
                {
                   // book.NameToken = typeDescription.NameToken;
                }
                Books.Add(book);
            }
        }

        public RedirectToPageResult OnPost()
        {
            book.NameToken = category.NameToken;
            _db.Add<local.Book>(book);
            _db.SaveChangesAsync();
            return RedirectToPage();
        }

    }
}
