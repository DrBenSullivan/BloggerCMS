using AutoMapper;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.DTO;

namespace BloggerCMS.Mapping
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile()
        {
            CreateMap<AccountDTO, Account>();
            CreateMap<BlogDTO, Blog>();
            CreateMap<BlogEntryDTO, BlogEntry>();
        }
    }
}