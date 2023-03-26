using Application.Model.AccountController;
using AutoMapper;
using Data.EFCore.Classes;

namespace Application.Profiles
{
    public class AccountProfile: Profile
    {
        public AccountProfile()
        {
            CreateMap<ApplicationUser, AccountSimpleModel>();
        }
    }
}
