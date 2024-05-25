using AseProda.Domain.DTO.Surtidores;
using AseProda.Domain.Enums;
using AseProda.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AseProda.Library
{
    public class AseProda
    {
        private readonly ISurtidorService _surtidorService;
        private readonly ILogger _logger;

        public AseProda(
            ISurtidorService surtidorService,
            ILogger logger)
        {
            _logger = logger;
            _surtidorService = surtidorService;
        }

        public async Task<bool> LiberarSurtidor(Surtidor surtidor)
        {
            try
            {
                await _surtidorService.PrefijarSurtidorAsync(surtidor);
                await _surtidorService.LiberarSurtidorAsync(surtidor);
                return true;
            }
            catch (Exception error)
            {
                _logger.LogError($"Excepción durante la liberación de surtidor con id {surtidor.Id}. Error : {error .Message}");
                return false;
            }
        }

        public async Task<bool> BloquearSurtidor(Surtidor surtidor)
        {
            try
            {
                await _surtidorService.BloquearSurtidorAsync(surtidor);
                return true;
            }
            catch (Exception error)
            {
                _logger.LogError($"Excepción durante el bloqueo de surtidor con Id {surtidor.Id}. Error : {error.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<EstadosSurtidor>> ObtenerEstadoSurtidor(IEnumerable<Surtidor> surtidores)
        {
            try
            {
                return await _surtidorService.ObtenerEstadosSurtidoresAsync(surtidores);
            }
            catch (Exception error)
            {
                _logger.LogError($"Excepción durante la obtención del estado de los surtidores. Error : {error.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<Suministro>> ObtenerHistoricoSuministrosAsync(IEnumerable<Surtidor> surtidores)
        {
            try
            {
                return await _surtidorService.ObtenerHistorialSuministrosAsync(surtidores);
            }
            catch (Exception error)
            {
                _logger.LogError($"Excepción durante la obtención del suministro historial de los surtidores. Error : {error.Message}");
                return null;
            }
        }
    }
}
