using AutoMapper;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.ViewModels;

namespace BloggerCMS.Mapping
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<Blog, NewBlogViewModel>();
            
            CreateMap<BlogEntry, NewEntryViewModel>();
        }

    }
}
