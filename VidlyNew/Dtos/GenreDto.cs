using System.ComponentModel.DataAnnotations;

namespace VidlyNew.Dtos
{
    public class GenreDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}