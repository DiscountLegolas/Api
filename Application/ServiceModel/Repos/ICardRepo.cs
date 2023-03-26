using Application.Model.CardController;
using Application.Model.CommentController;
using AutoMapper.Execution;
using Data.EFCore;
using Data.EFCore.Classes;
using Microsoft.EntityFrameworkCore;

namespace Application.ServiceModel.Repos
{
    public interface ICardRepo
    {
        public Card CreateCard(CardCreateUpdate card);
        public Card UpdateDescription(int id,string description);
        public Card AddAssingment(int id, string userıd);
        public Card RemoveAssingment(int id, string userıd);
    }
    public class CardRepo : ICardRepo
    {
        public ApplicationIdentityDbContext _dbcontext;
        public CardRepo(ApplicationIdentityDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public Card AddAssingment(int id, string userıd)
        {
            Card card = _dbcontext.Cards.First(X=>X.Id==id);
            if (card.Assingments.Any(x=>x.Member.WorkplaceMember.User.Id==userıd))
            {
                return card;
            }
            if (_dbcontext.BoardMembers.Count(x=>x.Board==card.CardList.Board&&x.WorkplaceMember.User.Id==userıd)==0)
            {
                _dbcontext.BoardMembers.Add(new BoardMember() { Board = card.CardList.Board, WorkplaceMember = _dbcontext.WorkplaceMembers.First(x => x.User.Id == userıd) });
            }
            _dbcontext.SaveChanges ();
            CardAssingment cardAssingment = new CardAssingment() {Card=card,Member= _dbcontext.BoardMembers.First(x=>x.WorkplaceMember.User.Id==userıd) };
            _dbcontext.CardAssingments.Add(cardAssingment);
            _dbcontext.SaveChanges ();
            return card;
        }

        public Card CreateCard(CardCreateUpdate card)
        {
            Card cardcreate=new Card() { Title=card.Title,CardList=_dbcontext.CardLists.First(x=>x.Id==card.CardListId)};
            _dbcontext.Cards.Add(cardcreate);
            _dbcontext.SaveChanges ();
            return cardcreate;
        }

        public Card RemoveAssingment(int id, string userıd)
        {
            CardAssingment cardAssingment=_dbcontext.CardAssingments.First(x=>x.Card.Id==id&&x.Member.WorkplaceMember.User.Id==userıd);
            Card card = cardAssingment.Card;
            _dbcontext.CardAssingments.Remove(cardAssingment);
            _dbcontext.SaveChanges();
            return card;
        }

        public Card UpdateDescription(int id, string description)
        {
            Card card = _dbcontext.Cards.First(X => X.Id == id);
            card.Desc = description;
            _dbcontext.SaveChanges ();
            return card;
        }
    }
}
