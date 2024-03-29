﻿using Application.Model.AccountController;
using Application.Model.CommentController;

namespace Application.Model.CardController
{
    public class CardModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int Index { get; set; }
        public List<AccountSimpleModel> AssingedUsers { get; set; }
        public List<CommentModel> Comments { get; set;}
    }
}
