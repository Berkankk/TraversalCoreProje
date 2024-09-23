using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTO;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Org.BouncyCastle.Crypto.Prng.Drbg;

namespace TraversalCoreProje.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();
            CreateMap<AnnouncementListDto, Announcement>().ReverseMap();
            CreateMap<AnnouncementUpdateDto, Announcement>().ReverseMap();
            CreateMap<AppUserRegisterDTO, AppUser>().ReverseMap();
            CreateMap<AppUserLoginDTO, AppUser>().ReverseMap();
            CreateMap<SendMessageDto, ContactUs>().ReverseMap();
        }
    }
}
