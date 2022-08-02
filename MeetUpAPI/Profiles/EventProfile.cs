using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace MeetUpAPI.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventModel>().ReverseMap();
        }
    }
}
