using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Models.Domain;
using RecipesAPI.Models.DTO.Comments;
using RecipesAPI.Repositories.Comments;

namespace RecipesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICommentsRepository commentsRepository;

        public CommentsController(IMapper mapper, ICommentsRepository commentsRepository)
        {
            this.mapper = mapper;
            this.commentsRepository = commentsRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await commentsRepository.GetAllAsync();

            return Ok(mapper.Map<List<CommentDto>>(comments));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCommentDto addCommentDto)
        {
            var commentDomain = mapper.Map<Comment>(addCommentDto);
            var response = await commentsRepository.CreateAsync(commentDomain);
            return Ok("Comment added");
        }
    }
}