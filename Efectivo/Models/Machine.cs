using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efectivo.Models
{
    public class Machine
    {
        public int ID { get; set; }
        public int PRECIO { get; set; }
        public int TIEMPO { get; set; }
        public int EFECTIVOINICIAL { get; set; }
        public Machine(int ID,int PRECIO, int TIEMPO, int EFECTIVOINICIAL)
        {
            this.ID = ID;
            this.PRECIO = PRECIO;
            this.TIEMPO = TIEMPO;
            this.EFECTIVOINICIAL = EFECTIVOINICIAL;
        }


    }
}
