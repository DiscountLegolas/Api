using Application.Model.CardController;
using Application.Model.CommentController;
using Application.ServiceModel.Repos;
using AutoMapper;
using Data.EFCore.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public readonly ICommentRepo _repo;
        public readonly IMapper mapper;
        public CommentController(ICommentRepo repo, IMapper mapper)
        {
            _repo = repo;
            this.mapper = mapper;
        }
        [Authorize]
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> AddComment([FromBody] CommentAdd model)
        {
            if (ModelState.IsValid)
            {
                var a = _repo.AddComment(model, User.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                return Ok(mapper.Map<Comment, CommentModel>(a));
            }
            return BadRequest("Model Yanlıştır.");
        }
        [Authorize]
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> CommentDelete([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var a = _repo.DeleteComment(id);
                return Ok(mapper.Map<Card, CardModel>(a));
            }
            return BadRequest("Model Yanlıştır.");
        }
        [Authorize]
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult> CommentUpdate([FromRoute] int id, [FromBody] CommentUpdate update)
        {
            if (ModelState.IsValid)
            {
                var a = _repo.UpdateComment(update,id);
                return Ok(mapper.Map<Comment, CommentModel>(a));
            }
            return BadRequest("Model Yanlıştır.");
        }
    }
}
