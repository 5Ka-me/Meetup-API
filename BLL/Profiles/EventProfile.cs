using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventModel>().ReverseMap();
        }
    }
}
