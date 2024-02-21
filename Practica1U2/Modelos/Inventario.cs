using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Inventario
    {
        public int Id { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public string Serie { get; set; }
        public string Color { get; set; }
        public DateTime FechaAdquision { get; set; }
        public string TipoAdquision { get; set; }
        public string Observaciones { get; set; }
        public int Areas_id { get; set; }
        public string Area { get; set; }
    }
}
