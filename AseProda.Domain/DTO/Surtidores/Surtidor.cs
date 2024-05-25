using AseProda.Domain.Enums;
using System;

namespace AseProda.Domain.DTO.Surtidores
{
    public class Surtidor
    {
        public int Id { get; set; }
        public EstadosSurtidor EstadoSurtidor { get; set; }
        public decimal SuministroPrefijado { get; set; }
        public decimal SuministroReal { get; set; }
        public DateTime FechaSuministro { get; set; }
        public bool SuministroFinalizado { get; set; }
    }
}
