using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrubeIngresoLogistica.Core.DTOs;
using PrubeIngresoLogistica.Core.DTOs.Entrega;
using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Interfaces.Services;

namespace PrubeIngresoLogistica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class EntregasController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IEntregaService _entregaService;

        public EntregasController(IMapper mapper, IEntregaService entregaService)
        {
            _mapper = mapper;
            _entregaService = entregaService;
        }

        [HttpGet("{id}")]
        public async Task<Entrega> Get(int id)
        {
            return await _entregaService.GetById(id);
        }

        [HttpGet]
 
        public async Task<IEnumerable<Entrega>> Get([FromQuery] FiltroReqDTO filtro)
        {
            return await _entregaService.Filter(filtro);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] EntregaReqDTO entregaReqDTO)
        {

            try
            {
                var entrega = _mapper.Map<Entrega>(entregaReqDTO);
                entrega = await _entregaService.Add(entrega);
                var entregaRes = _mapper.Map<EntregaResDTO>(entrega);

                return Ok(entregaRes);
            }
            catch 
            {

                return BadRequest();
            }


        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] EditarEntregaReqDTO dto)
        {
            var entrega = _mapper.Map<Entrega>(dto);
            entrega.Id = id;
            await _entregaService.Update(entrega);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _entregaService.Delete(id);

            return Ok();
        }
    }
}
