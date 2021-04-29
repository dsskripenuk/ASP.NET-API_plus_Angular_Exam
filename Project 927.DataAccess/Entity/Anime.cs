using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_927.API_Angular.Entity
{
    [Table("tblAnime")]
    public class Anime
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Episodes> Episodes { get; set; }

        [Required]
        public string Image { get; set; }

        public ICollection<Screenshots> Screenshots { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}
