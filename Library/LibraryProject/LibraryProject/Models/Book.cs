using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibraryProject.Models
{
    public class Book
    {
        [Key]

        public int Id { get; set; }

        [DisplayName("Book Name")]
        public string BookName { get; set; }
        [DisplayName("Author Name")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please Enter the price")]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        public string Slug => BookName == null ? "" : BookName.Replace(' ', '-');
    }
}
