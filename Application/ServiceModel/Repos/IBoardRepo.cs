using Application.Model.BoardController;
using Application.Model.WorkplaceController;
using Data.EFCore;
using Data.EFCore.Classes;

namespace Application.ServiceModel.Repos
{
    public interface IBoardRepo
    {
        public Board GetBoard(Guid id);
        public Board CreateBoard(BoardCreateModel model);
    }
    public class BoardRepo : IBoardRepo
    {
        public ApplicationIdentityDbContext _dbcontext;
        public BoardRepo(ApplicationIdentityDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public Board CreateBoard(BoardCreateModel model)
        {
            Board board = new Board() { Title = model.Title, Workplace = _dbcontext.Workplaces.First(x=>x.WorkplaceId== model.WorkPlaceId)};
            _dbcontext.Boards.Add(board);
            _dbcontext.SaveChanges();
            return board;
        }

        public Board GetBoard(Guid id)
        {
            return _dbcontext.Boards.FirstOrDefault(x=>x.Id==id);
        }
    }
}
