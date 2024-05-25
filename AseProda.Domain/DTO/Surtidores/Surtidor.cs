using AseProda.Domain.Enums;

namespace AseProda.Domain.DTO.Surtidores
{
    public class Surtidor
    {
        public int Id { get; set; }
        public EstadosSurtidor EstadoSurtidor { get; set; }
        public decimal SuministroPrefijado { get; set; }
        public decimal SuministroReal { get; set; }
    }
}
