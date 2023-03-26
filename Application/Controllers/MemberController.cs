using Application.Model.BoardController;
using Application.Model.CardController;
using Application.Model.CommentController;
using Application.Model.MemberController;
using Application.Model.WorkplaceController;
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
    public class MemberController : ControllerBase
    {
        public readonly IMemberRepo _repo;
        public readonly IMapper mapper;
        public MemberController(IMemberRepo repo, IMapper mapper)
        {
            _repo = repo;
            this.mapper = mapper;
        }
        [Authorize]
        [HttpPost]
        [Route("Board/AddMember")]
        public async Task<ActionResult> BoardAddMember([FromBody] BoardAddRemoveMember model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var a = _repo.AddBoardMember(model);
                    return Ok(mapper.Map<Board, BoardModel>(a));

                }
                catch (Exception)
                {
                    return NotFound();
                }
            }
            return BadRequest("Model Yanlıştır.");
        }
        [Authorize]
        [HttpPost]
        [Route("Board/RemoveMember")]
        public async Task<ActionResult> BoardRemoveMember([FromBody] BoardAddRemoveMember model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var a = _repo.RemoveBoardMember(model);
                    return Ok(mapper.Map<Board, BoardModel>(a));
                }
                catch (Exception)
                {
                    return NotFound();
                }

            }
            return BadRequest("Model Yanlıştır.");
        }
        [Authorize]
        [HttpPost]
        [Route("Workplace/AddMember")]
        public async Task<ActionResult> WorkplaceAddMember([FromBody] WorkplaceAddRemoveMember model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var a = _repo.AddWorkplaceMember(model);
                    return Ok(mapper.Map<Workplace, WorkPlaceModel>(a));
                }
                catch (Exception)
                {
                    return NotFound();
                }

            }
            return BadRequest("Model Yanlıştır.");
        }
        [Authorize]
        [HttpPost]
        [Route("Workplace/RemoveMember")]
        public async Task<ActionResult> WorkplaceRemoveMember([FromBody] WorkplaceAddRemoveMember model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var a = _repo.RemoveWorkplaceMember(model);
                    return Ok(mapper.Map<Workplace, WorkPlaceModel>(a));
                }
                catch (Exception)
                {
                    return NotFound();
                }

            }
            return BadRequest("Model Yanlıştır.");
        }
    }
}
