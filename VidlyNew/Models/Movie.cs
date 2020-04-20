using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyNew.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleasedDate { get; set; }

        
        public DateTime DateAdded { get; set; }

        [Display(Name = "Quantity in stock")]
        public int QuantityInStock { get; set; }           


        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

    }
}