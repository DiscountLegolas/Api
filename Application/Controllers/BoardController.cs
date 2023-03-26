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
                return Ok(_mapper.Map<Board,BoardModel>(boardRepo.GetBoard(id)));
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
    }
}
