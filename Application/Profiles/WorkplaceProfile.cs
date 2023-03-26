using Application.Model.AccountController;
using Application.Model.WorkplaceController;
using Application.Model.WorkplaceMemberController;
using AutoMapper;
using Data.EFCore.Classes;

namespace Application.Profiles
{
    public class WorkplaceProfile: Profile
    {
        public WorkplaceProfile()
        {
            CreateMap<WorkplaceMember, WorkplaceMemberModel>().ForMember(x => x.UserId, opt => opt.MapFrom(a => a.User.Id)).ForMember(x => x.Email, opt => opt.MapFrom(a => a.User.Email)).ForMember(x => x.UserName, opt => opt.MapFrom(a => a.User.UserName));
            CreateMap<Workplace, WorkPlaceModel>().ForMember(dest => dest.Members, opt => opt.MapFrom(a => a.Members)).ForMember(x => x.Boards, o => o.MapFrom(s => s.Boards));
            CreateMap<Workplace, WorkPlaceSimpleModel>().ForMember(dest => dest.Members, opt => opt.MapFrom(a => a.Members)).ForMember(x=>x.Boards,o=>o.MapFrom(s=>s.Boards));
        }
    }
}
