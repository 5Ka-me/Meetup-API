using AutoMapper;
using BLL.Models;
using DAL.Entities;
using MeetUpAPI.ViewModels;

namespace MeetUpAPI.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventViewModel, EventModel>().ReverseMap();
            CreateMap<Event, EventModel>().ReverseMap();
        }
    }
}
