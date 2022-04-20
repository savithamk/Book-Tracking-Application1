using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using schema = Schema.NET;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Tracking_Application_Models
{
    public class Book
    {
        [Key]
        [Required]
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

    }
}
