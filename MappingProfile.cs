using AutoMapper;
using WorkPoint_WebApp.Entities.Models;
using WorkPoint_WebApp.Shared.DataTransferObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WorkPoint_WebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IHttpContextAccessor httpContextAccessor) 
        {
            var request = httpContextAccessor?.HttpContext?.Request;
            var domain = $"{request?.Scheme}://{request?.Host.ToUriComponent()}{request?.PathBase.ToUriComponent()}";
            CreateMap<News, NewsReturnDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Detail1, opt => opt.MapFrom(src => src.Detail1))
                .ForMember(dest => dest.Detail2, opt => opt.MapFrom(src => src.Detail2))
                .ForMember(dest => dest.Detail3, opt => opt.MapFrom(src => src.Detail3))
                .ForMember(dest => dest.Picture1, opt => opt.MapFrom(src => src.Picture1 == null ? "" : domain + $"/Picture/{src.Picture1}"))
                .ForMember(dest => dest.Picture1FileName, opt => opt.MapFrom(src => src.Picture1 == null ? "" : src.Picture1))
                .ForMember(dest => dest.Picture2, opt => opt.MapFrom(src => src.Picture2 == null ? "" : $"{domain}/Picture/{src.Picture2}"))
                .ForMember(dest => dest.Picture2FileName, opt => opt.MapFrom(src => src.Picture2 == null ? "" : src.Picture2))
                .ForMember(dest => dest.Picture3, opt => opt.MapFrom(src => src.Picture3 == null ? "" : $"{domain}/Picture/{src.Picture3}"))
                .ForMember(dest => dest.Picture3FileName, opt => opt.MapFrom(src => src.Picture3 == null ? "" : src.Picture3))
                .ForMember(dest => dest.Picture4, opt => opt.MapFrom(src => src.Picture4 == null ? "" : $"{domain}/Picture/{src.Picture4}"))
                .ForMember(dest => dest.Picture4FileName, opt => opt.MapFrom(src => src.Picture4 == null ? "" : src.Picture4))
                .ForMember(dest => dest.Picture5, opt => opt.MapFrom(src => src.Picture5 == null ? "" : $"{domain}/Picture/{src.Picture5}"))
                .ForMember(dest => dest.Picture5FileName, opt => opt.MapFrom(src => src.Picture5 == null ? "" : src.Picture5))
                .ForMember(dest => dest.Picture6, opt => opt.MapFrom(src => src.Picture6 == null ? "" : $"{domain}/Picture/{src.Picture6}"))
                .ForMember(dest => dest.Picture6FileName, opt => opt.MapFrom(src => src.Picture6 == null ? "" : src.Picture6))
                .ForMember(dest => dest.Picture7, opt => opt.MapFrom(src => src.Picture7 == null ? "" : $"{domain}/Picture/{src.Picture7}"))
                .ForMember(dest => dest.Picture7FileName, opt => opt.MapFrom(src => src.Picture7 == null ? "" : src.Picture7))
                .ForMember(dest => dest.Picture8, opt => opt.MapFrom(src => src.Picture8 == null ? "" : $"{domain}/Picture/{src.Picture8}"))
                .ForMember(dest => dest.Picture8FileName, opt => opt.MapFrom(src => src.Picture8 == null ? "" : src.Picture8))
                .ForMember(dest => dest.Picture9, opt => opt.MapFrom(src => src.Picture9 == null ? "" : $"{domain}/Picture/{src.Picture9}"))
                .ForMember(dest => dest.Picture9FileName, opt => opt.MapFrom(src => src.Picture9 == null ? "" : src.Picture9))
                .ForMember(dest => dest.Picture10, opt => opt.MapFrom(src => src.Picture10 == null ? "" : $"{domain}/Picture/{src.Picture10}"))
                .ForMember(dest => dest.Picture10FileName, opt => opt.MapFrom(src => src.Picture10 == null ? "" : src.Picture10));
            CreateMap<NewsDto,News>();
        }
    }
}
