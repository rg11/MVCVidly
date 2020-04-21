using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.ViewModels
{
    public class MovieFormViewModel
    {                        

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleasedDate { get; set; }
                                                   

        [Required]
        [Range(1, 20, ErrorMessage = "Can not order less than 1 and greater than 20 ")]
        [Display(Name = "Quantity in stock")]
        public int? QuantityInStock { get; set; }
                                

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }


        public IEnumerable<Genre> Genres { get; set; }


        public string Title {
            get
            {
                return (Id > 0) ? "Edit Movie View" : "New Movie View";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;                             
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            GenreId = movie.GenreId;
            QuantityInStock = movie.QuantityInStock;          
        }
    }
}