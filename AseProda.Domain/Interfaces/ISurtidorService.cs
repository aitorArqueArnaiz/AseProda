using AseProda.Domain.DTO.Surtidores;
using AseProda.Domain.Enums;
using AseProda.Domain.Responses.Estados;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AseProda.Domain.Interfaces
{
    public interface ISurtidorService
    {
        Task<Surtidor> LiberarSurtidorAsync(Surtidor surtidor);
        Task<decimal> PrefijarSurtidorAsync(Surtidor surtidor);
        Task<IEnumerable<EstadoSurtidor>> ObtenerEstadosSurtidoresAsync(IEnumerable<Surtidor> surtidores);
        Task<Surtidor> BloquearSurtidorAsync(Surtidor surtidor);
        Task<IEnumerable<Suministro>> ObtenerHistorialSuministrosAsync(IEnumerable<Surtidor> surtidores);
    }
}
