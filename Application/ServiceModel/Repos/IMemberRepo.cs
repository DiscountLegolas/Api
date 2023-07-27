using Application.Model.MemberController;
using Data.EFCore;
using Data.EFCore.Classes;
using Microsoft.EntityFrameworkCore;

namespace Application.ServiceModel.Repos
{
    public interface IMemberRepo
    {
        public Board AddBoardMember(BoardAddRemoveMember member);
        public Board RemoveBoardMember(BoardAddRemoveMember member);
        public Workplace AddWorkplaceMember(WorkplaceAddRemoveMember member);
        public Workplace RemoveWorkplaceMember(WorkplaceAddRemoveMember member);
        public Task<List<ApplicationUser>> FilterMembers(string q);
    }
    public class MemberRepo : IMemberRepo
    {
        public ApplicationIdentityDbContext _dbcontext;
        public MemberRepo(ApplicationIdentityDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public Board AddBoardMember(BoardAddRemoveMember member)
        {
            Board board = _dbcontext.Boards.First(x => x.Id == member.BoardId);
            if (board.BoardMembers.Any(x=>x.WorkplaceMember.User.Id==member.UserId))
            {
                return board;
            }
            BoardMember boardMember = new BoardMember() { Board = board, WorkplaceMember = board.Workplace.Members.First(x => x.User.Id == member.UserId) };
            _dbcontext.BoardMembers.Add(boardMember);
            _dbcontext.SaveChanges();
            return board;
        }

        public Workplace AddWorkplaceMember(WorkplaceAddRemoveMember member)
        {
            Workplace workplace = _dbcontext.Workplaces.First(x => x.WorkplaceId == member.WorkplaceId);
            if (workplace.Members.Any(x => x.User.Id == member.UserId))
            {
                return workplace;
            }
            WorkplaceMember workplaceMember = new WorkplaceMember() { Workplace = workplace, User = _dbcontext.Users.First(x=>x.Id==member.UserId) };
            _dbcontext.WorkplaceMembers.Add(workplaceMember);
            _dbcontext.SaveChanges();
            return workplace;
        }

        public async Task<List<ApplicationUser>> FilterMembers(string q)
        {
            List<ApplicationUser> users=await _dbcontext.Users.Where(x=>x.Email.ToLower().Contains(q.ToLower())).ToListAsync();
            return users;
        }

        public Board RemoveBoardMember(BoardAddRemoveMember member)
        {
            BoardMember boardMember=_dbcontext.BoardMembers.First(x=>x.Board.Id == member.BoardId&&x.WorkplaceMember.User.Id==member.UserId);
            Board board= boardMember.Board;
            _dbcontext.BoardMembers.Remove(boardMember);
            _dbcontext.SaveChanges();
            return board;
        }

        public Workplace RemoveWorkplaceMember(WorkplaceAddRemoveMember member)
        {
            WorkplaceMember workplaceMember = _dbcontext.WorkplaceMembers.First(x => x.Workplace.WorkplaceId == member.WorkplaceId && x.User.Id == member.UserId);
            Workplace workplace = workplaceMember.Workplace;
            _dbcontext.WorkplaceMembers.Remove(workplaceMember);
            _dbcontext.SaveChanges();
            return workplace;
        }
    }
}
