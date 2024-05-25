using AseProda.Domain.DTO.Surtidores;
using AseProda.Domain.Enums;
using AseProda.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AseProda.Domain.Services
{
    public class SurtidorService : ISurtidorService
    {
        public async Task BloquearSurtidorAsync(Surtidor surtidor)
        {
            surtidor.EstadoSurtidor = EstadosSurtidor.Bloqueado;
            surtidor.SuministroPrefijado = 0.0M;
        }

        public async Task<Surtidor> LiberarSurtidorAsync(Surtidor surtidor)
        {
            surtidor.EstadoSurtidor = EstadosSurtidor.Libre;
            return surtidor;
        }

        public async Task<IEnumerable<EstadosSurtidor>> ObtenerEstadosSurtidoresAsync(IEnumerable<Surtidor> surtidores)
        {
            return surtidores.Select(x => x.EstadoSurtidor).ToList();
        }

        public async Task<decimal> PrefijarSurtidorAsync(Surtidor surtidor)
        {
            surtidor.SuministroPrefijado = default;
            return surtidor.SuministroPrefijado;
        }
    }
}
