using Application.Model.BoardController;
using Application.ServiceModel.Repos;
using AutoMapper;
using Data.EFCore;
using Data.EFCore.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        public IBoardRepo boardRepo;
        private readonly IMapper _mapper;
        public BoardController(IBoardRepo boardRepo,IMapper mapper)
        {
            _mapper = mapper;
            this.boardRepo = boardRepo;
        }
        [Route("Get/{id}")]
        [HttpGet]
        public async Task<ActionResult> BoardGetDetail([FromRoute] Guid id)
        {
            if (ModelState.IsValid)
            {
                var board=await boardRepo.GetBoard(id);
                board.Lists=board.Lists.OrderBy(x=>x.Index).ToList();
                return Ok(_mapper.Map<Board,BoardModel>(board));
            }
            return BadRequest("Model Yanlıştır.");
        }
        [Authorize]
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult> BoardCreate([FromBody] BoardCreateModel model)
        {
            if (ModelState.IsValid)
            {
                boardRepo.CreateBoard(model);
                return Ok();
            }
            return BadRequest("Model Yanlıştır.");
        }
        [Authorize]
        [Route("Delete/{boardıd}")]
        [HttpDelete]
        public async Task<ActionResult> BoardDelete([FromRoute] Guid boardıd)
        {
            await boardRepo.DeleteBoard(boardıd);
            return Ok();
        }
    }
}
