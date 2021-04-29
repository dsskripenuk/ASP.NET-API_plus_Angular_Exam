using System;
using System.Collections.Generic;
using System.Text;

namespace Project_927.DTO.Anime
{
    public class EpisodesDTO
    {
        public int Id { get; set; }
        public int Season { get; set; }
        public string Img_URL { get; set; }
        public string Video_URL { get; set; }
        public AnimeDTO anime { get; set; }
    }
}
