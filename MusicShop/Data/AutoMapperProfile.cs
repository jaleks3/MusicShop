using AutoMapper;
using MusicShop.Models;
using MusicShop.Models.DTOs;

namespace MusicShop.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Record, GetRecordDTO>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.RecordStorages.Sum(rs => rs.Quantity)))
                .ForMember(dest => dest.Distributor, opt => opt.MapFrom(src => src.Distributor))
                .ForMember(dest => dest.Artists, opt => opt.MapFrom(src => src.Artists))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres));
        }
    }
}
