using Application.Model.CardListController;
using Data.EFCore;
using Data.EFCore.Classes;

namespace Application.ServiceModel.Repos
{
    public interface ICardListRepo
    {
        public CardList Create(CardListCreate model );
    }
    public class CardListRepo : ICardListRepo
    {
        public ApplicationIdentityDbContext _dbcontext;
        public CardListRepo(ApplicationIdentityDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public CardList Create(CardListCreate model)
        {
            Board board = _dbcontext.Boards.First(x => x.Id == model.BoardId);
            CardList cardList = new CardList { Title = model.Title, Board = board,Index=board.Lists.Count+1 };
            _dbcontext.CardLists.Add(cardList);
            _dbcontext.SaveChanges();
            return cardList;
        }
    }
}
