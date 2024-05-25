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

        public async Task<IEnumerable<Suministro>> ObtenerHistorialSuministrosAsync(IEnumerable<Surtidor> surtidores)
        {
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
            surtidor.SuministroPrefijado = default;
            return surtidor.SuministroPrefijado;
        }
    }
}
