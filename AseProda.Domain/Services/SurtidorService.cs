using AseProda.Domain.DTO.Surtidores;
using AseProda.Domain.Enums;
using AseProda.Domain.Interfaces;
using AseProda.Domain.Responses.Estados;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AseProda.Domain.Services
{
    public class SurtidorService : ISurtidorService
    {
        public async Task<Surtidor> BloquearSurtidorAsync(Surtidor surtidor)
        {
            if (surtidor.EstadoSurtidor != EstadosSurtidor.Bloqueado)
            {
                surtidor.EstadoSurtidor = EstadosSurtidor.Bloqueado;
                surtidor.SuministroPrefijado = 0.0M;
            }

            return surtidor;
        }

        public async Task<Surtidor> LiberarSurtidorAsync(Surtidor surtidor)
        {
            if (surtidor.EstadoSurtidor != EstadosSurtidor.Libre)
                surtidor.EstadoSurtidor = EstadosSurtidor.Libre;

            return surtidor;
        }

        public async Task<IEnumerable<EstadoSurtidor>> ObtenerEstadosSurtidoresAsync(IEnumerable<Surtidor> surtidores)
        {
            if (surtidores == null || !surtidores.Any())
                return null;

            return surtidores.Select(x => new EstadoSurtidor() { Estado = x.EstadoSurtidor, Id = x.Id }).ToList();
        }

        public async Task<IEnumerable<Suministro>> ObtenerHistorialSuministrosAsync(IEnumerable<Surtidor> surtidores)
        {
            if (surtidores == null || !surtidores.Any())
                return null;

            var surtidoresPorBloquear = surtidores.Where(x => x.SuministroFinalizado);
            foreach(var surtidor in surtidoresPorBloquear)
            {
                surtidor.SuministroPrefijado = 0.0M;
                await BloquearSurtidorAsync(surtidor);
            }

            var suministroSurtidores = surtidores.Where(x => !x.SuministroFinalizado).Select(x => new Suministro() 
            {
                Surtidor = x,
                FechaSuministro = x.FechaSuministro,
                ImportePrefijado = x.SuministroPrefijado,
                ImporteRealizado = x.SuministroReal
            }).OrderBy(x => x.FechaSuministro).OrderByDescending(x => x.ImporteRealizado);

            return suministroSurtidores;
        }

        public async Task<decimal> PrefijarSurtidorAsync(Surtidor surtidor)
        {
            surtidor.SuministroPrefijado = 20.0M;
            return surtidor.SuministroPrefijado;
        }
    }
}
