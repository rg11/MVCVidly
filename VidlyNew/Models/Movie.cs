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

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleasedDate { get; set; }

        
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20,ErrorMessage ="Can not order less than 1 and greater than 20 ")]
        [Display(Name = "Quantity in stock")]
        public int QuantityInStock { get; set; }           


        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

    }
}