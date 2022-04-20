using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Book_Tracking_Application_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Book_Tracking_Application_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public Book Book { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Book = new Book() { ISBN = "3SDE457DHF", Title = "New Book", Author = "Savitha", ReleaseDate = DateTime.Now};
        }

        public void OnGet()
        {

        }
    }
}
