using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using MeetUpAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MeetUpAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly IEventService _productService;
        private readonly IMapper _mapper;

        public EventController(ILogger<EventController> logger, IEventService productService, IMapper mapper)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EventViewModel>> Get(CancellationToken cancellationToken)
        {
            var models = await _productService.Get(cancellationToken);

            return _mapper.Map<IEnumerable<EventViewModel>>(models);
        }

        [HttpGet("{id}")]
        public async Task<EventViewModel> Get(int id, CancellationToken cancellationToken)
        {
            var eventModel = await _productService.Get(id, cancellationToken);

            return _mapper.Map<EventViewModel>(eventModel);
        }

        [HttpPost]
        public async Task<EventViewModel> Create(EventViewModel productViewModel, CancellationToken cancellationToken)
        {
            var eventModel = _mapper.Map<EventModel>(productViewModel);

            eventModel = await _productService.Create(eventModel, cancellationToken);

            _mapper.Map(eventModel, productViewModel);

            return productViewModel;
        }

        [HttpPut]
        public async Task<EventViewModel> Update(EventViewModel productViewModel, CancellationToken cancellationToken)
        {
            var eventModel = _mapper.Map<EventModel>(productViewModel);

            eventModel = await _productService.Update(eventModel, cancellationToken);

            _mapper.Map(eventModel, productViewModel);

            return productViewModel;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _productService.Delete(id, cancellationToken);
        }
    }
}