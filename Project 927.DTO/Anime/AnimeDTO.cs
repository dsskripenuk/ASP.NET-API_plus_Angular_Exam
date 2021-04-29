using Project_927.DTO.Anime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_927.DTO
{
    public class AnimeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<EpisodesDTO> Episodes { get; set; }
        public string Image { get; set; }
        public List<ScreenshotsDTO> Screenshots { get; set; }
        public string ReleaseDate { get; set; }
        public CategoryDTO category { get; set; }
    }
}
