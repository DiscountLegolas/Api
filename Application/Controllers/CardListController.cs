using Application.Model.BoardController;
using Application.Model.CardListController;
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
    public class CardListController : ControllerBase
    {
        public readonly ICardListRepo repo;
        public readonly IMapper mapper;
        public CardListController(ICardListRepo repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        [Authorize]
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CardListCreate([FromBody] CardListCreate model)
        {
            if (ModelState.IsValid)
            {
                var a=repo.Create(model);
                return Ok(mapper.Map<CardList,CardListModel>(a));
            }
            return BadRequest("Model Yanlıştır.");
        }
    }
}
