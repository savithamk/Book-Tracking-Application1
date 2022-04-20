using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using schema = Schema.NET;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using Schema.NET;
using System.Linq;

namespace Book_Tracking_Application_Models
{
    public class Book
    {

        [Key]
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [ForeignKey("NameToken")]
        [Display(Name = "Category")]
        public string NameToken { get; set; }


        private Thing JSONLD { get; set; } = new Thing();

        public schema.Thing GetJson()
        {
            schema.Book book = new schema.Book();

            book.About = new schema.OneOrMany<schema.IThing>(new List<schema.Thing>() { new schema.Thing() { Name = this.Title } });
            book.Isbn = this.ISBN;
           // book.Author. = this.Author;
           // book.ReleaseDate = this.ReleaseDate;

            return book;
        }

    }
}
