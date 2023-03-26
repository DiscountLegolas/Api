using System.ComponentModel.DataAnnotations;
using Application.Model.CardController;

namespace Application.Model.CardListController
{
    public class CardListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Index { get; set; }
        public List<CardModel> Cards { get; set; }
    }
}
