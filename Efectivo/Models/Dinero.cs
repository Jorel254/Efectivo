using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Efectivo.Annotations;
using GoldenToolKit;

namespace Efectivo.Models
{

    public abstract class Dinero : ModelBase
    {
        public enum TipoEfectivo { Moneda = 1, Billete = 2 }
        public int Valor 
        { 
            get => valor;
            set
            {
                valor = value;
                OnPropertyChanged();
            }
        }
        public string Nombre { get; set; }
        public TipoEfectivo Tipo { get; set; }


        public int _Cantidad;
        private int valor;

        public int Cantidad
        {
            get => _Cantidad;
            set
            {
                _Cantidad = value;
                OnPropertyChanged();
            }
        }

        //Total con propiedad automatizada reduce la complejidad y evita errores
        public int Total
        {
            get
            {
                return Valor * Cantidad;
            }
        }
        public string Imagen { get; set; }
        protected Dinero(string Nombre, int Valor, int Cantidad, TipoEfectivo Tipo, string Imagen)
        {
            this.Nombre = Nombre;
            this.Valor = Valor;
            this.Tipo = Tipo;
            this.Cantidad = Cantidad;
            this.Imagen = Imagen;
        }
    }
}
