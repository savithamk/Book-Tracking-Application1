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
    public class AddCategoryTypeModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BookCatalogue _db;

        [FromForm]
        public CategoryType categoryType { get; set; }
        public List<CategoryType> CategoryTypes { get;  set; }

        public AddCategoryTypeModel(ILogger<IndexModel> logger, BookCatalogue db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            var categoryTypeQuery = _db.categoryTypes.Select(categoryType => categoryType);
            CategoryTypes = categoryTypeQuery.ToList();

        }

        public RedirectToPageResult OnPost()
        {
                _db.Add<CategoryType>(categoryType);
                _db.SaveChangesAsync();
            
            return RedirectToPage();
        }
    }
}
