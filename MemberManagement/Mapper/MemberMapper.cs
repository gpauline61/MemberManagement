using AutoMapper;
using MemberManagement.Application.DTO.MemberDTO;
using MemberManagement.Domain.Entities;
using MemberManagement.Web.ViewModels.MemberViewModel;

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

        }
    }
}
