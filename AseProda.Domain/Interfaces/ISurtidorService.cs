using AseProda.Domain.DTO.Surtidores;
using AseProda.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AseProda.Domain.Interfaces
{
    public interface ISurtidorService
    {
        Task<Surtidor> LiberarSurtidorAsync(Surtidor surtidor);
        Task<decimal> PrefijarSurtidorAsync(Surtidor surtidor);
        Task<IEnumerable<EstadosSurtidor>> ObtenerEstadosSurtidoresAsync(IEnumerable<Surtidor> surtidores);
        Task BloquearSurtidorAsync(Surtidor surtidor);
        Task<IEnumerable<Suministro>> ObtenerHistorialSuministrosAsync(IEnumerable<Surtidor> surtidores);
    }
}
