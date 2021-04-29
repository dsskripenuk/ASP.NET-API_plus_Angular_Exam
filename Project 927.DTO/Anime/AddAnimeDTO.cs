using System;
using System.Collections.Generic;
using System.Text;

namespace Project_927.DTO.Anime
{
    public class AddAnimeDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ReleaseDate { get; set; }
        public int CategoryId { get; set; }
    }
}
