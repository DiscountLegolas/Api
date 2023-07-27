using Application.Model.AccountController;
using Application.Model.CardListController;
using Data.EFCore.Classes;

namespace Application.Model.BoardController
{
    public class BoardModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PicUrl { get; set; }
        public List<CardListModel> Lists { get; set; }
        public List<AccountSimpleModel> BoardMembers { get; set; }
        public List<AccountSimpleModel> PossibleMembers { get; set; }


    }
    public class BoardSimpleModel
    {
        public Guid Id { get; set; }
        public string PicUrl { get; set; }

        public string Title { get; set; }
    }
}
