using AutoMapper;
using BCP.ExchangeRate.Domain;
using BCP.ExchangeRate.WebAPI.Models.Request;

namespace BCP.ExchangeRate.WebAPI.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AuthRequest, User>()
                .ForMember(dest => dest.UserName, source => source.MapFrom(source => source.Username));


            //CreateMap<Audio, AudioValidateDto>().ReverseMap();
            //CreateMap<Audio, AudioValidateDto>()
            //    .ForMember(dest => dest.AudioId, source => source.MapFrom(source => source.IdMaterial))
            //    .ForMember(dest => dest.DateLastModified, source => source.MapFrom(source => source.LastWriteTime.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'")));

        }
    }
}