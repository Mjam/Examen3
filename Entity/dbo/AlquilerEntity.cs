using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AlquilerEntity: EN
    {
        public AlquilerEntity()
        {
            Cliente = Cliente ?? new ClientesEntity();
           

        }
        public int? IdAlquiler { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime FechaFin { get; set; } = DateTime.Now;
        public decimal Monto { get; set; }
        public decimal Impuesto { get; set; }
        public string Total { get; set; }
        public string Observaciones { get; set; }


        public int? ClientesId { get; set; }
        public virtual ClientesEntity Cliente { get; set; }

        public int? VehiculoId { get; set; }
        public VehiculoEntity Vehiculo { get; set; }

    }
}
