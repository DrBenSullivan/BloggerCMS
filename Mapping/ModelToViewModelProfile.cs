using AutoMapper;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.ViewModels;

namespace BloggerCMS.Mapping
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            #region Blog ViewModel Mapping Transform
            CreateMap<Blog, NewBlogViewModel>();
            #endregion
        }

    }
}
