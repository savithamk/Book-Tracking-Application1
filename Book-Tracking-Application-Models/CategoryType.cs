using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Book_Tracking_Application_Models
{
    public class CategoryType
    {

        [Key]
        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}
