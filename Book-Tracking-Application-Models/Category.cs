using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Book_Tracking_Application_Models
{
    public class Category
    {
        [Key]
        [Required]
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string NameToken { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [ForeignKey("CategoryType")]
        [Display(Name = "CategoryType")]
        public int Type { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
