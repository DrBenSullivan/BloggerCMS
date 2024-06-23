using AutoMapper;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.DTO;

namespace BloggerCMS.Mapping
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<Account, AccountDTO>();
            CreateMap<Blog, BlogDTO>();
            CreateMap<BlogEntry, BlogEntryDTO>();
        }
    }
}