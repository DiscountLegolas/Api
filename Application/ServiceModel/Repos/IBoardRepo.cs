using Application.Model.BoardController;
using Application.Model.WorkplaceController;
using Data.EFCore;
using Data.EFCore.Classes;
using Microsoft.EntityFrameworkCore;

namespace Application.ServiceModel.Repos
{
    public interface IBoardRepo
    {
        public Task DeleteBoard(Guid boardıd);
        public Task<Board> GetBoard(Guid id);
        public Task<Board> CreateBoard(BoardCreateModel model);
    }
    public class BoardRepo : IBoardRepo
    {
        public ApplicationIdentityDbContext _dbcontext;
        public BoardRepo(ApplicationIdentityDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<Board> CreateBoard(BoardCreateModel model)
        {
            Board board = new Board() { Title = model.Title,PicUrl=model.PicUrl, Workplace = _dbcontext.Workplaces.First(x=>x.WorkplaceId== model.WorkPlaceId)};
            _dbcontext.Boards.Add(board);
            await _dbcontext.SaveChangesAsync();
            return  board;
        }

        public async Task DeleteBoard(Guid boardıd)
        {
            _dbcontext.Boards.Remove(await _dbcontext.Boards.FirstAsync(x => x.Id == boardıd));
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Board> GetBoard(Guid id)
        {
            try
            {
                var h = await _dbcontext.Boards.FirstOrDefaultAsync(x => x.Id == id);
                Console.WriteLine(h);
                return h;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
