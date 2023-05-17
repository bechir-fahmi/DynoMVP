using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.DTO.TicketData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Dyno.Platform.ReferentialData.WebApi.Controllers.UserData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dyno.Platform.ReferentialData.WebApi.Controllers.TicketData
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ILogger<TicketController> _logger;


        public TicketController(ITicketService ticketService, ILogger<TicketController> logger)
        {
           _ticketService = ticketService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllTicket")]

        public IActionResult GetAll()
        {
            IList<TicketDTO> ticketDTOs = _ticketService.GetAll();
            return Ok(ticketDTOs);
        }

        [HttpPost]
        [Route("AddTicket")]
        public IActionResult Add([FromBody] TicketDTO ticketDTO)
        {
            _ticketService.Create(ticketDTO);

            return Ok(ticketDTO);

        }

        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            TicketDTO ticketDTO = _ticketService.GetById(id);
            return Ok(ticketDTO);
        }
    }
}
