using Application.Model.CommentController;
using Data.EFCore;
using Data.EFCore.Classes;
using Microsoft.EntityFrameworkCore;

namespace Application.ServiceModel.Repos
{
    public interface ICommentRepo
    {
        public Comment AddComment(CommentAdd Create,string userid);
        public Comment UpdateComment(CommentUpdate update,int id);
        public Card DeleteComment(int id);


    }
    public class CommentRepo : ICommentRepo
    {
        public ApplicationIdentityDbContext _dbcontext;
        public CommentRepo(ApplicationIdentityDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public Comment AddComment(CommentAdd Create, string userid)
        {
            Comment comment = new Comment() { Text = Create.Text, Card = _dbcontext.Cards.First(x => x.Id == Create.CardId), User = _dbcontext.Users.First(x => x.Id == userid) };
            _dbcontext.Comments.Add(comment);
            _dbcontext.SaveChanges();
            return comment;
        }

        public Card DeleteComment(int id)
        {
            Comment comment= _dbcontext.Comments.First(x => x.Id == id);
            Card a=comment.Card;
            _dbcontext.Comments.Remove(comment);
            _dbcontext.SaveChanges();
            return a;
        }

        public Comment UpdateComment(CommentUpdate update, int id)
        {
            Comment comment = _dbcontext.Comments.First(x => x.Id == id);
            comment.Text = update.Text;
            _dbcontext.SaveChanges();
            return comment;
        }
    }
}
