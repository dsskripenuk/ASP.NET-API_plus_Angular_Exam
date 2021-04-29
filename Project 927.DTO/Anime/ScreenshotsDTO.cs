using System;
using System.Collections.Generic;
using System.Text;

namespace Project_927.DTO.Anime
{
    public class ScreenshotsDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public AnimeDTO anime { get; set; }
    }
}
