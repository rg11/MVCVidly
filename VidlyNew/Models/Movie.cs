﻿using System;
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

        public DateTime ReleasedDate { get; set; }
        public DateTime DateAdded { get; set; }

        public int QuantityInStock { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }

    }
}