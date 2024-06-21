using AutoMapper;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.ViewModels;

namespace BloggerCMS.Mapping
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            #region Blog ViewModel Mapping Transform
            CreateMap<NewBlogViewModel, Blog>()
                .ForMember(
                    dest => dest.Author,
                    opt => opt.MapFrom(
                        src => src.Accounts.FirstOrDefault(
                            a => a.Id == src.AuthorId)));
            #endregion
        }
    }
}
