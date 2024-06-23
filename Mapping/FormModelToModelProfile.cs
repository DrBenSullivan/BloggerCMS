using AutoMapper;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.FormModels;

namespace BloggerCMS.Mapping
{
    public class FormModelToModel : Profile
    {
        public FormModelToModel()
        {
            CreateMap<NewEntryFormModel, BlogEntry>();
        }
    }
}