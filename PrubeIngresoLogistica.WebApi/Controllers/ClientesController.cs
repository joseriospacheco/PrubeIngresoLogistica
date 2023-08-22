using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrubeIngresoLogistica.Core.DTOs.Cliente;
using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Interfaces.Services;


namespace PrubeIngresoLogistica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ClientesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;

        public ClientesController(IMapper mapper, IClienteService clienteService)
        {
            _mapper = mapper;
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ClienteReqDTO clienteDTO)
        {

            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDTO);
                await _clienteService.Add(cliente);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }


        }


    }
}
