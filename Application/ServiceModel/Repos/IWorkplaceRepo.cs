using Application.Model.WorkplaceController;
using Data.EFCore;
using Data.EFCore.Classes;
using Microsoft.EntityFrameworkCore;

namespace Application.ServiceModel.Repos
{
    public interface IWorkplaceRepo
    {
        public Task DeleteWorkplace(int workplaceıd);
        public ICollection<Workplace> GetUserWorkplaces(string userId);
        public Workplace CreateWorkplace(string userId,WorkplaceCreateModel model);

    }
    public class WorkplaceRepo : IWorkplaceRepo
    {
        public ApplicationIdentityDbContext _dbcontext;
        public WorkplaceRepo(ApplicationIdentityDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public Workplace CreateWorkplace(string userId, WorkplaceCreateModel model)
        {
            Workplace workplace = new Workplace() { WorkplaceName=model.Name,Description=model.Description};
            _dbcontext.Workplaces.Add(workplace);
            _dbcontext.SaveChanges();
            _dbcontext.WorkplaceMembers.Add(new WorkplaceMember() { Workplace=workplace,User = _dbcontext.Users.First(x => x.Id == userId),Admin=true});
            _dbcontext.SaveChanges();
            return workplace;
        }

        public async Task DeleteWorkplace(int workplaceıd)
        {
            _dbcontext.Workplaces.Remove(await _dbcontext.Workplaces.FirstAsync(x => x.WorkplaceId==workplaceıd));
            await _dbcontext.SaveChangesAsync();
        }

        public ICollection<Workplace> GetUserWorkplaces(string userId)
        {
            return _dbcontext.Workplaces.Where(x=>x.Members.Count(a=>a.User.Id==userId) >0).ToList();
        }
    }
}
