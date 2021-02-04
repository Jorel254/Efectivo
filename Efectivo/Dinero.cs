using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Efectivo.Annotations;

namespace Efectivo
{
    //Implementar INotifyPropertyChanged para mantener la cantidad actualizada siempre sin
    //tener que sacar y meter el elemento
    public abstract class Dinero : INotifyPropertyChanged
    {
        public enum TipoEfectivo { Moneda = 1, Billete = 2 }
        public int Valor { get; set; }
        public string Nombre { get; set; }
        public TipoEfectivo Tipo { get; set; }


        public int _Cantidad;
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

        protected Dinero(string Nombre, int Valor, int Cantidad, TipoEfectivo Tipo)
        {
            this.Nombre = Nombre;
            this.Valor = Valor;
            this.Tipo = Tipo;
            this.Cantidad = Cantidad;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
