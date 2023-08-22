using PrubeIngresoLogistica.Core.DTOs;
using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Enumerations;
using PrubeIngresoLogistica.Core.Interfaces.Repositories;
using PrubeIngresoLogistica.Core.Interfaces.Services;
using PrubeIngresoLogistica.Core.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.Services
{
    public class EntregaService : IEntregaService
    {

        private readonly IUnitOfWork _unitOfWork;

        public EntregaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GenerarNumeroGuia()
        {

            string numeroGuia = GenerarorNumeroGuia.GenerarNumeroGuia();

            if (await _unitOfWork.EntregaRepository.GetByNumeroGuia(numeroGuia))
            {
                await GenerarNumeroGuia();
            }

            return numeroGuia;
        }

        public async Task<Entrega> Add(Entrega entity)
        {

            entity.FechaRegistro = DateTime.Now;
            entity.NumeroGuia = await GenerarNumeroGuia();

            var lugarDestino = await _unitOfWork.LugarDestinoRepository.GetById(entity.LugarDestinoId);
            var cliente = await _unitOfWork.ClienteRepository.GetById(entity.ClienteId);

            if (lugarDestino is not null)
            {

                entity.Descuento = CalcularDescuento(entity.CantidadPoducto, lugarDestino.Tipo, entity.ValorEnvio);
                entity.ValorEnvioTotal = entity.ValorEnvio - entity.Descuento;

            }


            await _unitOfWork.EntregaRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();

            entity.Cliente = cliente;

            return entity;

        }

        public async Task<bool> Delete(int id)
        {
             await _unitOfWork.EntregaRepository.Delete(id);

            return await _unitOfWork.SaveChangesAsync()>0? true: false;
        }


        public async  Task<IEnumerable<Entrega>> Filter(FiltroReqDTO filtro)
        {
          return await _unitOfWork.EntregaRepository.Filter(filtro);
        }

        public async Task<Entrega> GetById(int id)
        {
            return await _unitOfWork.EntregaRepository.GetById(id); 
        }

        public async Task Update(Entrega entity)
        {

            var entregaEncontrada = await _unitOfWork.EntregaRepository.GetById(entity.Id);

            if (entregaEncontrada is not null) {


                entregaEncontrada.ClienteId = entity.ClienteId;
                entregaEncontrada.CantidadPoducto = entity.CantidadPoducto;
                entregaEncontrada.LugarDestinoId = entity.LugarDestinoId;
                entregaEncontrada.TipoProductoId = entity.TipoProductoId;

                var lugarDestino = await _unitOfWork.LugarDestinoRepository.GetById(entity.LugarDestinoId);


                entregaEncontrada.Descuento = CalcularDescuento(entregaEncontrada.CantidadPoducto, lugarDestino.Tipo, entregaEncontrada.ValorEnvio);
                entregaEncontrada.ValorEnvioTotal = entregaEncontrada.ValorEnvio - entregaEncontrada.Descuento;



                await _unitOfWork.EntregaRepository.Update(entregaEncontrada);
                await _unitOfWork.SaveChangesAsync();

            }

           
        }

        public double CalcularDescuento(double cantidad, TipoLugarDestino tipoLugarDestino, double valorEnvio)
        {

            if (cantidad > 10)
            {

                if (tipoLugarDestino == TipoLugarDestino.BODEGA)
                {
                    return valorEnvio * 0.05;

                }
                else if (tipoLugarDestino == TipoLugarDestino.PUERTO)
                {
                    return valorEnvio * 0.03;
                }

            }

            return 0;

        }
    }
}
