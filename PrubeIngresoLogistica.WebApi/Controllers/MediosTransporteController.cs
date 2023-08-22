using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrubeIngresoLogistica.Core.DTOs.MedioTransporte;
using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Enumerations;
using PrubeIngresoLogistica.Core.Interfaces.Services;
using System.Text.RegularExpressions;


namespace PrubeIngresoLogistica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class MediosTransporteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMedioTranspoteService _medioTranspoteService;

        public MediosTransporteController(IMapper mapper, IMedioTranspoteService medioTranspoteService)
        {
            _mapper = mapper;
            _medioTranspoteService = medioTranspoteService;
        }





        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] MedioTransporteReqDTO dto)
        {

            if ((dto.TipoMedioTransporte ==  TipoMedioTransporte.VEHICULO && Regex.IsMatch(dto.Matricula, "^[A-Za-z]{3}\\d{3}$"))
                || dto.TipoMedioTransporte ==  TipoMedioTransporte.FLOTA && Regex.IsMatch(dto.Matricula, "^[A-Za-z]{3}\\d{4}[A-Za-z]$"))
            {
                var medioTransporte = _mapper.Map<MedioTransporte>(dto);

                await _medioTranspoteService.Add(medioTransporte);

                return Ok();

            }
            else
            {
                return StatusCode(422, "Error al procesar la Información");
            }

            
        }
    }
}