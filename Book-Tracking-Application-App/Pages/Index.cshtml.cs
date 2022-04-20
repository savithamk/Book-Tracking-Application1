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

namespace Book_Tracking_Application_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public Thing JSONLD { get { return Book.GetJson(); } }

        public local.Book Book { get; set; } = new local.Book();


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Book.ISBN = "isbn";
            Book.Title = "New Book";
            Book.Author = "savitha";
        }

        public void OnGet()
        {
            /*Book book = new Book();


            book.About = new OneOrMany<IThing>(new List<Thing>() { new Thing() { Name = "Test Book" } });
            book.Isbn = @"23ERFGN";
            book.Text = "New Book";
            // book.Author = Savitha;
            // book.ReleaseDate = DateTime.Now;

            JSONLD = book;*/
        }
    }
}
