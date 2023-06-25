using Application.Model.BoardController;
using Application.Model.WorkplaceController;
using Application.Model.WorkplaceMemberController;
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
    public class WorkplaceController : ControllerBase
    {
        public IWorkplaceRepo workplaceRepo;
        private readonly IMapper _mapper;
        public WorkplaceController(IWorkplaceRepo workplaceRepo,IMapper mapper)
        {
            this.workplaceRepo = workplaceRepo;
            this._mapper = mapper;
        }


        [Authorize]
        [Route("Get")]
        [HttpGet]
        public async Task<ActionResult> WorkspacesGet()
        {
            var claims = User.Claims.ToList();
            string userıd = claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine(userıd);
            var b = workplaceRepo.GetUserWorkplaces(userıd);
            List<WorkPlaceSimpleModel> WorkPlaces = _mapper.Map<ICollection<Workplace>,List<WorkPlaceSimpleModel>>(b);
            WorkPlacesModel workPlaces = new WorkPlacesModel() { WorkPlaces= WorkPlaces };
            return Ok(workPlaces);
        }

        [Authorize]
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult> WorkspaceCreate([FromBody] WorkplaceCreateModel model)
        {
            var claims = User.Claims.ToList();
            string userıd = claims?.FirstOrDefault(x => x.Type==ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine(userıd);
            if (ModelState.IsValid)
            {
                var b= workplaceRepo.CreateWorkplace(userıd, model);
                return Ok(b);
            }
            return BadRequest("Model Yanlıştır.");
        }
        [Authorize]
        [Route("Delete/{workplaceıd}")]
        [HttpDelete]
        public async Task<ActionResult> WorkspaceDelete([FromRoute] int workplaceıd)
        {
            await workplaceRepo.DeleteWorkplace(workplaceıd);
            return Ok();
        }
    }
}
