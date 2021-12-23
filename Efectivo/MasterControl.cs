using GoldenToolKit.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Efectivo
{
    public class MasterControl : ContentControl, INavigationPage
    {
        public static MasterControl Current { get; private set; }
        //public List<IUserControlInterface> ControlInterfaces { get; set; }
        Dictionary<string, IUserControlInterface> ControlInterfaces { get; set; }
        public IUserControlInterface Actual { get; set; }
        public List<string> ControlViews { get; set; }

        public IUserControlInterface GoBack()
        {
            int indice = ControlViews.FindIndex(p => p == Actual.GetType().Name);
            if (indice == 0 )
            {
                
            }else
            {
                
                if (ControlInterfaces.TryGetValue(ControlViews[indice - 1], out IUserControlInterface value))
                {
                    Actual = value;
                    return Actual;
                }
            }
           
            return Actual;
        }

        public IUserControlInterface GoFoward()
        {

            int indice = ControlViews.FindIndex(p => p == Actual.GetType().Name);
            
                if (!(indice > ControlViews.Count))
                {
                    if (ControlInterfaces.TryGetValue(ControlViews[indice + 1], out IUserControlInterface value))
                    {
                        Actual = value;
                        return Actual;
                    }
                }
               
            

            return Actual;
        }
        public void Navegar(IUserControlInterface usercontrol)
        {
           
            this.Content = usercontrol;
            var temp = usercontrol.GetType();
            if (!ControlInterfaces.ContainsKey(temp.Name))
            {
                ControlViews.Add(temp.Name);
                ControlInterfaces.Add(temp.Name,usercontrol);
            }
            Actual = usercontrol;
            usercontrol.OnShown();
        }

        public void SendMessage(IUserControlInterface control, string json)
        {
            control.OnMessageReceived(json);
        }

        public void SendMessage<T>(string json) where T : IUserControlInterface
        {
            //Encontrar la ventana del tipo T y enviarle el mensajito
            //si no esta arroja una excepcion
            throw new NotImplementedException();
        }

        public void Navegar<T>(object parameter = null) where T : IUserControlInterface
        {
            T controltemp = (T)Activator.CreateInstance(typeof(T));
            var temp = controltemp.GetType();
            if (ControlInterfaces.TryGetValue(temp.Name, out IUserControlInterface value))
            {
               
                Content = value;
                Actual = value;
                value.OnShown();
            }else
            {
                ControlViews.Add(temp.Name);
                ControlInterfaces.Add(temp.Name,controltemp);
                Content = controltemp;
                Actual = controltemp;
                controltemp.OnShown();
            }
            
        }

        public IUserControlInterface GetCurrentControl()
        {
            return (IUserControlInterface)this.Content;
        }

        public MasterControl()
        {
            Current = this;
            ControlViews = new List<string>();
            ControlInterfaces = new Dictionary<string, IUserControlInterface>();
        }
    }
}
