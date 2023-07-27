using Application.Model.AccountController;
using Application.Model.BoardController;
using Application.Model.CardController;
using Application.Model.CardListController;
using Application.Model.CommentController;
using AutoMapper;
using Data.EFCore.Classes;

namespace Application.Profiles
{
    public class BoardProfile: Profile
    {
        public BoardProfile()
        {
            CreateMap<Comment, CommentModel>();
            CreateMap<BoardMember,AccountSimpleModel>().ForMember(x=>x.Id,opt=>opt.MapFrom(a=>a.WorkplaceMember.User.Id)).ForMember(x => x.Email, opt => opt.MapFrom(a => a.WorkplaceMember.User.Email)).ForMember(x => x.Name, opt => opt.MapFrom(a => a.WorkplaceMember.User.UserName));
            CreateMap<WorkplaceMember, AccountSimpleModel>().ForMember(x => x.Id, opt => opt.MapFrom(a => a.User.Id)).ForMember(x => x.Email, opt => opt.MapFrom(a => a.User.Email)).ForMember(x => x.Name, opt => opt.MapFrom(a => a.User.UserName));
            CreateMap<Card, CardModel>().ForMember(x => x.AssingedUsers, opt => opt.MapFrom(a => a.Assingments.Select(c=>c.Member)));
            CreateMap<CardList, CardListModel>();
            CreateMap<Board, BoardModel>().ForMember(x=>x.PossibleMembers,opt=>opt.MapFrom(a=>a.Workplace.Members));
            CreateMap<Board, BoardSimpleModel>();

        }
    }
}
