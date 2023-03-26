using Application.Model.CardController;
using Application.Model.CommentController;
using Application.ServiceModel.Repos;
using AutoMapper;
using Data.EFCore.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> CardAddComment([FromBody] CommentAdd model)
        {
            if (ModelState.IsValid)
            {
                var a = _repo.AddComment(model);
                return Ok(mapper.Map<Card, CardModel>(a));
            }
            return BadRequest("Model Yanlıştır.");
        }
        [Authorize]
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> CardDelete([FromRoute] int id)
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
        public async Task<ActionResult> CardDelete([FromRoute] int id, [FromBody] CommentUpdate update)
        {
            if (ModelState.IsValid)
            {
                var a = _repo.UpdateComment(update,id);
                return Ok(mapper.Map<Card, CardModel>(a));
            }
            return BadRequest("Model Yanlıştır.");
        }
    }
}
