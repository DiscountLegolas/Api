using Application.Model.AccountController;
using Application.Model.BoardController;
using Application.Model.CardController;
using Application.Model.CardListController;
using AutoMapper;
using Data.EFCore.Classes;

namespace Application.Profiles
{
    public class BoardProfile: Profile
    {
        public BoardProfile()
        {
            CreateMap<BoardMember,AccountSimpleModel>().ForMember(x=>x.Id,opt=>opt.MapFrom(a=>a.WorkplaceMember.User.Id)).ForMember(x => x.Email, opt => opt.MapFrom(a => a.WorkplaceMember.User.Email)).ForMember(x => x.Name, opt => opt.MapFrom(a => a.WorkplaceMember.User.UserName));
            CreateMap<Card, CardModel>().ForMember(x => x.AssingedUsers, opt => opt.MapFrom(a => a.Assingments.Select(c=>c.Member)));
            CreateMap<CardList, CardListModel>();
            CreateMap<Board, BoardModel>();
            CreateMap<Board, BoardSimpleModel>();
        }
    }
}
