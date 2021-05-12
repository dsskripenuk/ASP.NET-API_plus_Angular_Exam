using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_927.API_Angular.Helper;
using Project_927.DataAccess;
using Project_927.DTO.News;
using Project_927.DTO.Results;

namespace Project_927.API_Angular.Controllers
{
    [Route("api/ManagerController")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class ManagerPanelController : ControllerBase
    {
        EFContext _context;

        public ManagerPanelController(EFContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IQueryable<NewsDTO> GetNews()
        {
            var data = _context.News.Select(t => new NewsDTO
            {
                Id = t.Id,
                Title = t.Title,
                Content = t.Content,
                Image = t.Image,
                ReleaseDate = t.ReleaseDate
            });

            return data;
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public ResultDTO addNews([FromBody] AddNewsDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultErrorDTO
                {
                    Code = 400,
                    Errors = CustomValidator.getErrorsByModelState(ModelState)
                };
            }

            _context.News.Add(new DataAccess.Entity.News
            {
                Title = model.Title,
                Content = model.Content,
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

        [HttpPost("RemoveNews/{Id}")]
        public ResultDTO RemoveNews([FromRoute] int id)
        {
            try
            {
                var anime = _context.News.FirstOrDefault(t => t.Id == id);

                _context.News.Remove(anime);
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

        [HttpPost("editNews/{id}")]
        public ResultDTO EditNews([FromRoute] int id, [FromBody] NewsDTO model)
        {
            var anime = _context.News.FirstOrDefault(t => t.Id == id);

            anime.Title = model.Title;
            anime.Content = model.Content;
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
