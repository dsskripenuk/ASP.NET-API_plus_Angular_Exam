using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_927.API_Angular.Entity;
using Project_927.API_Angular.Helper;
using Project_927.DataAccess;
using Project_927.DTO;
using Project_927.DTO.Anime;
using Project_927.DTO.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_927.API_Angular.Controllers
{
    [Route("api/AnimeManager")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : ControllerBase
    {
        EFContext _context;

        public AdminPanelController(EFContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<AnimeDTO> GetAnimes()
        {
            var data = _context.Animes.Select(t => new AnimeDTO
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Image = t.Image,
                ReleaseDate = t.ReleaseDate
            });

            return data;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ResultDTO addAnime([FromBody] AddAnimeDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultErrorDTO
                {
                    Code = 400,
                    Errors = CustomValidator.getErrorsByModelState(ModelState)
                };
            }

            _context.Animes.Add(new Anime
            {
                Title = model.Title,
                Description = model.Description,
                Image = model.Image,
                ReleaseDate = model.ReleaseDate
            });

            _context.SaveChanges();

            return new ResultDTO
            {
                Code = 200,
                Message = "Success!"
            };
        }

        [HttpPost("RemoveAnime/{Id}")]
        public ResultDTO RemoveAnime([FromRoute] int id)
        {
            try
            {
                var anime = _context.Animes.FirstOrDefault(t => t.Id == id);

                _context.Animes.Remove(anime);
                _context.SaveChanges();

                return new ResultDTO
                {
                    Code = 200,
                    Message = "Success!"
                };
            }
            catch (Exception e)
            {
                List<string> temp = new List<string>();
                temp.Add(e.Message);

                return new ResultErrorDTO
                {
                    Code = 500,
                    Message = "ERROR",
                    Errors = temp
                };
            }
        }

        [HttpPost("editAnime/{id}")]
        public ResultDTO EditAnime([FromRoute] int id, [FromBody] AnimeDTO model)
        {
            var anime = _context.Animes.FirstOrDefault(t => t.Id == id);

            anime.Title = model.Title;
            anime.Description = model.Description;
            anime.Image = model.Image;
            anime.ReleaseDate = model.ReleaseDate;

            _context.SaveChanges();

            return new ResultDTO
            {
                Code = 200,
                Message = "OK"
            };
        }
    }
}
