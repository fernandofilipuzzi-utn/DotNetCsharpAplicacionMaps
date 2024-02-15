using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsModels.Models
{
    public class Entrega
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdZona { get; set; }
        public int IdRepartido { get; set; }
        public DateTime FechaHoraDisponible { get; set; }
       
    }
}
