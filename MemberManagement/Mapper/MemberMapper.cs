using AutoMapper;
using MemberManagement.Application.DTO.MemberDTO;
using MemberManagement.Application.DTO.MembershipDTO;
using MemberManagement.Domain.Entities;
using MemberManagement.Web.ViewModels.MembershipVM;
using MemberManagement.Web.ViewModels.MemberVM;

namespace MemberManagement.Web.Mapper
{
    public class MemberMapper : Profile
    {
        public MemberMapper()
        {
            CreateMap<MemberIndexDTO, Member>();
            CreateMap<Member, MemberIndexDTO>();

            CreateMap<MemberCreateDTO, Member>();
            CreateMap<Member, MemberCreateDTO>();

            CreateMap<MemberDetailDTO, Member>();
            CreateMap<Member, MemberDetailDTO>();

            CreateMap<MemberActiveInactiveDTO, Member>();
            CreateMap<Member, MemberActiveInactiveDTO>();

            CreateMap<Member, MemberEditDTO>();

            CreateMap<MemberActiveInactiveDTO, MemberActiveInactiveViewModel>();
            CreateMap<MemberIndexDTO, MemberIndexViewModel>();
            CreateMap<MemberDetailDTO, MemberDetailDeleteViewModel>();
            CreateMap<Member, MemberCreateViewModel>();
            CreateMap<MemberEditDTO, MemberEditViewModel>();

            CreateMap<Membership, MembershipIndexDTO>();
            CreateMap<MembershipIndexDTO, MembershipIndexViewModel>();
            CreateMap<MembershipDetailDTO, MembershipDetailViewModel>();
            CreateMap<Membership, MembershipDetailDTO>();
            CreateMap<Membership, MembershipDetailViewModel>();
            CreateMap<MembershipEditDTO, MembershipEditViewModel>();
            CreateMap<Membership, MembershipEditDTO>();
        }
    }
}
