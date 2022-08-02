using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetUpAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _eventService.Get(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _eventService.Get(id, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] EventModel eventModel, CancellationToken cancellationToken)
        {
            return Ok(await _eventService.Create(eventModel, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update(EventModel eventModel, CancellationToken cancellationToken)
        {
            return Ok(await _eventService.Update(eventModel, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _eventService.Delete(id, cancellationToken);
        }
    }
}