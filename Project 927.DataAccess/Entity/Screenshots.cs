using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_927.API_Angular.Entity
{
    [Table("tblScreenshots")]
    public class Screenshots
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int AnimeId { get; set; }
        public Anime anime { get; set; }
    }
}
