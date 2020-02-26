using System;
using System.Collections.Generic;
using System.Linq;
using HackerNews.Model;
using HackerNews.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackerNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryRepository _repository;

        public StoryController(IStoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Story>> Get()
        {
            try
            {
                IEnumerable<Story> stories = _repository
                                                .GetBestStoryIds(20)
                                                .Select(id =>  _repository.GetStory(id));

                return Ok(stories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
