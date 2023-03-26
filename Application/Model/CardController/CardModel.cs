using Application.Model.AccountController;

namespace Application.Model.CardController
{
    public class CardModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public List<AccountSimpleModel> AssingedUsers { get; set; }
    }
}
