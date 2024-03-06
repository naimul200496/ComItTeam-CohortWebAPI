using AutoMapper;
using PostingAPI.Models;
using PostingAPI.Models.Dto;

namespace PostingAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PostingDto, Posting>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
