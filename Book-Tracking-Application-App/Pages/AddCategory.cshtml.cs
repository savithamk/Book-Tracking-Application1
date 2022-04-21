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
    public class AddCategoryModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BookCatalogue _db;

        [FromForm]
        public Category category { get; set; }
        public List<Category> Categories { get; private set; }

        [FromForm]
        public CategoryType categoryType { get; set; }
        public List<CategoryType> CategoryTypes { get;  set; }

        public List<SelectListItem> CategorySelectionItems = new List<SelectListItem>();

        public AddCategoryModel(ILogger<IndexModel> logger, BookCatalogue db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            Categories = new List<Category>();
            CategoryTypes = new List<CategoryType>();
            var categoryTypesQuery = _db.categoryTypes.Select(categoryType => categoryType);
            var categoryQuery = _db.Categories.Select(category => category);
            CategoryTypes = categoryTypesQuery.ToList();
            foreach (CategoryType type in CategoryTypes) {
                SelectListItem item = new SelectListItem(type.Name, type.Type);
                CategorySelectionItems.Add(item);
            }
            foreach (Category category in categoryQuery.ToList()) {
                var categoryType = Categories.Find(categoryType => category.Type.Equals(category.Type));
                if (null != categoryType) {
                    category.Type = categoryType.ToString();
                }
                Categories.Add(category);
            }

        }

        public RedirectToPageResult OnPost()
        {
            
            category.Type = categoryType.Type;
            _db.Add<Category>(category);
            _db.SaveChangesAsync();
            
            return RedirectToPage();
        }
    }
}
