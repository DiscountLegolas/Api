using Application.Model.AccountController;
using Data.EFCore.Classes;

namespace Application.Model.CommentController
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual AccountSimpleModel User { get; set; }
    }
}
