using System;

namespace AseProda.Domain.DTO.Surtidores
{
    public class Suministro
    {
        public Surtidor Surtidor { get; set; }
        public DateTime FechaSuministro { get; set; }
        public decimal ImportePrefijado { get; set; }
        public decimal ImporteRealizado { get; set; }
    }
}
