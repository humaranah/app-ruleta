using AppRuleta.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppRuleta.ViewModel
{
    public class InicioViewModel : ViewModelBase
    {
        private string background;

        public string Background
        {
            get
            {
                return background;
            }

            set
            {
                background = value;
                RaisePropertyChanged();
            }
        }

        public InicioViewModel()
        {
            if(IsInDesignMode)
            {
                //
            }
            else
            {
                Cargar();
            }
        }

        public void Cargar()
        {
            if (File.Exists("config.xml"))
            {
                Config config;
                XmlSerializer xs = new XmlSerializer(typeof(Config));
                using (StreamReader sr = new StreamReader("config.xml"))
                {
                    config = xs.Deserialize(sr) as Config;
                }
                Background = config.ImagenInicio;
            }
        }
    }
}
