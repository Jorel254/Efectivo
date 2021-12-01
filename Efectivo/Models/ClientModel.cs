using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efectivo.Models
{
    public class ClientModel
    {
        public Guid ID { get; set; }
        public DateTime Hora { get; set; }
        public int Pagado { get; set; }

        public ClientModel()
        {

        }
        public ClientModel(Guid ID, DateTime Hora, int Pagado)
        {
            this.ID = ID;
            this.Hora= Hora;
            this.Pagado = Pagado;
        }
    }
}
