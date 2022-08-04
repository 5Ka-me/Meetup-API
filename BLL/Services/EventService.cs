using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<EventModel> _validator;

        public EventService(IEventRepository eventRepository, IMapper mapper, IValidator<EventModel> validator)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<EventModel> Update(EventModel eventModel, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(eventModel, cancellationToken);

            var @event = await _eventRepository.GetById(eventModel.Id, cancellationToken);

            CheckNullEvent(@event);

            var eventTemp = await _eventRepository.GetByTheme(eventModel.Theme, cancellationToken);

            if (eventTemp != null && eventTemp.Id != eventModel.Id)
            {
                throw new ArgumentException("A event with the same theme already exists", nameof(eventModel));
            }

            _mapper.Map(eventModel, @event);

            await _eventRepository.Update(@event, cancellationToken);

            return _mapper.Map(@event, eventModel);
        }

        public async Task<EventModel> Create(EventModel eventModel, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(eventModel, cancellationToken);

            if (await _eventRepository.GetByTheme(eventModel.Theme, cancellationToken) != null)
            {
                throw new ArgumentException("A event with the same theme already exists", nameof(eventModel));
            }

            var @event = _mapper.Map<Event>(eventModel);

            await _eventRepository.Create(@event, cancellationToken);

            return _mapper.Map(@event, eventModel);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetById(id, cancellationToken);

            CheckNullEvent(@event);

            await _eventRepository.Delete(@event, cancellationToken);
        }

        public async Task<IEnumerable<EventModel>> Get(CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.Get(cancellationToken);

            return _mapper.Map<IEnumerable<EventModel>>(@event);
        }

        public async Task<EventModel> Get(int id, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetById(id, cancellationToken);

            CheckNullEvent(@event);

            return _mapper.Map<EventModel>(@event);
        }

        private static void CheckNullEvent(Event? @event)
        {
            if (@event == null)
            {
                throw new ArgumentNullException(nameof(@event), "Event does not exist");
            }
        }
    }
}
