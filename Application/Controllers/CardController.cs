using Application.Model.CardController;
using Application.Model.CardListController;
using Application.Model.CommentController;
using Application.Model.MemberController;
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
    public class CardController : ControllerBase
    {
        public readonly ICardRepo _repo;
        public readonly IMapper mapper;
        public CardController(ICardRepo repo,IMapper mapper)
        {
            _repo = repo;
            this.mapper = mapper;
        }
        [Authorize]
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CardCreate([FromBody] CardCreateUpdate model)
        {
            if (ModelState.IsValid)
            {
                var a = await _repo.CreateCard(model);
                return Ok(mapper.Map<Card, CardModel>(a));
            }
            return BadRequest("Model Yanlıştır.");
        }
        [Authorize]
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult> CardUpdate([FromRoute] int id,[FromBody] CardCreateUpdate model)
        {
            if (ModelState.IsValid)
            {
                var a = await _repo.UpdateCard(id,model);
                return Ok(mapper.Map<Card, CardModel>(a));
            }
            return BadRequest("Model Yanlıştır.");
        }
        [Authorize]
        [HttpPost]
        [Route("AddAssingment")]
        public async Task<ActionResult> CardAddAssingment([FromBody] CardAddRemoveAssingment model)
        {
            if (ModelState.IsValid)
            {
                var a = _repo.AddAssingment(model.CardId, model.UserId);
                return Ok(mapper.Map<Card, CardModel>(a));
            }
            return BadRequest("Model Yanlıştır.");
        }
        [Authorize]
        [HttpPost]
        [Route("RemoveAssingment")]
        public async Task<ActionResult> CardRemoveAssingment([FromBody] CardAddRemoveAssingment model)
        {
            if (ModelState.IsValid)
            {
                var a = _repo.RemoveAssingment(model.CardId, model.UserId);
                return Ok(mapper.Map<Card, CardModel>(a));
            }
            return BadRequest("Model Yanlıştır.");
        }
    }
}
