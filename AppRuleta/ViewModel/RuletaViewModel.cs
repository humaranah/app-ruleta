using AppRuleta.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppRuleta.ViewModel
{
    public class RuletaViewModel : ViewModelBase
    {
        private Random random;

        private ObservableCollection<string> premios;
        private int intentos;
        private int premio;
        private string fondo;

        public RelayCommand Girar { get; set; }

        public ObservableCollection<string> Premios
        {
            get
            {
                return premios;
            }

            set
            {
                premios = value;
                RaisePropertyChanged();
            }
        }

        public int Intentos
        {
            get
            {
                return intentos;
            }

            set
            {
                intentos = value;
                RaisePropertyChanged();
            }
        }

        public int Premio
        {
            get
            {
                return premio;
            }

            set
            {
                premio = value;
                RaisePropertyChanged();
            }
        }

        public string Fondo
        {
            get
            {
                return fondo;
            }

            set
            {
                fondo = value;
                RaisePropertyChanged();
            }
        }

        public RuletaViewModel()
        {
            Girar = new RelayCommand(delegate { girar(); });

            if (IsInDesignMode)
            {
                Premios = new ObservableCollection<string>();
                for (int i = 0; i < 12; i++)
                {
                    Premios.Add("Premio " + i);
                }
                Intentos = 3;
            }
            else
            {
                random = new Random();
                Cargar();
            }
        }

        public void Cargar()
        {
            var collection = new ObservableCollection<string>();
            if (File.Exists("config.xml"))
            {
                Config config;
                XmlSerializer xs = new XmlSerializer(typeof(Config));
                using (StreamReader sr = new StreamReader("config.xml"))
                {
                    config = xs.Deserialize(sr) as Config;
                }
                foreach (var item in config.Premios)
                {
                    collection.Add(item.Value);
                }
                Intentos = config.Intentos;
                Fondo = config.FondoRuleta;
            }
            Premios = collection;
        }

        private void girar()
        {
            int idPremio = random.Next(0,12);
            Premio = idPremio;
        }
    }
}
