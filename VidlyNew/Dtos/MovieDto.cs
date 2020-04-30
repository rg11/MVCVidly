using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyNew.App_Start;

namespace VidlyNew.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]       
        public DateTime ReleasedDate { get; set; }
                                    

        [Required]    
        public int QuantityInStock { get; set; }

                                           
        [Required]       
        public int GenreId { get; set; }

        public MovieDto()
        {
            this.DateAdded = DateTime.UtcNow;
        }
    }
}