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
    public class ConfiguracionViewModel : ViewModelBase
    {
        private ObservableCollection<StringElement> campos;
        private ObservableCollection<StringElement> premios;
        private int intentos;
        private bool guardado;
        private string imagenInicio;
        private string fondoFormulario;
        private string fondoRuleta;

        public RelayCommand AgregarCampo { get; set; }
        public RelayCommand<object> BorrarCampo { get; set; }
        public RelayCommand Guardar { get; set; }

        public ObservableCollection<StringElement> Campos
        {
            get
            {
                return campos;
            }

            set
            {
                if (campos != value)
                {
                    campos = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ObservableCollection<StringElement> Premios
        {
            get
            {
                return premios;
            }

            set
            {
                if (premios != value)
                {
                    premios = value;
                    RaisePropertyChanged();
                }
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
                if (intentos != value)
                {
                    intentos = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool Guardado
        {
            get
            {
                return guardado;
            }

            set
            {
                guardado = value;
                RaisePropertyChanged();
            }
        }

        public string ImagenInicio
        {
            get
            {
                return imagenInicio;
            }

            set
            {
                imagenInicio = value;
                RaisePropertyChanged();
            }
        }

        public string FondoFormulario
        {
            get
            {
                return fondoFormulario;
            }

            set
            {
                fondoFormulario = value;
                RaisePropertyChanged();
            }
        }

        public string FondoRuleta
        {
            get
            {
                return fondoRuleta;
            }

            set
            {
                fondoRuleta = value;
                RaisePropertyChanged();
            }
        }

        public ConfiguracionViewModel()
        {
            Campos = new ObservableCollection<StringElement>();
            Premios = new ObservableCollection<StringElement>();
            Intentos = new int();

            AgregarCampo = new RelayCommand(() =>
            {
                Campos.Add(new StringElement() { Value = "" });
            });

            BorrarCampo = new RelayCommand<Object>((se) =>
            {
                if (se is StringElement)
                {
                    Campos.Remove(se as StringElement);
                }
            });

            Guardar = new RelayCommand(delegate { guardar(); });

            if (IsInDesignMode)
            {
                for (int i = 0; i < 5; i++)
                {
                    Campos.Add(new StringElement { Value = "Campo de prueba " + i });
                }
                for (int i = 0; i < 12; i++)
                {
                    Premios.Add(new StringElement("Premio " + i));
                }
                Intentos = 3;
            }
            else
            {
                cargar();
            }
        }

        private void guardar()
        {
            var config = new Config()
            {
                Campos = campos.ToList(),
                Premios = premios.ToList(),
                Intentos = intentos,
                ImagenInicio = ImagenInicio,
                FondoFormulario = FondoFormulario,
                FondoRuleta = FondoRuleta
            };
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            using (StreamWriter sw = new StreamWriter("config.xml", false))
            {
                xs.Serialize(sw, config);
                Guardado = true;
            }
        }

        private void cargar()
        {
            Config config;
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            if(File.Exists("config.xml"))
            {
                using (StreamReader sr = new StreamReader("config.xml"))
                {
                    config = xs.Deserialize(sr) as Config;
                }
                Campos = new ObservableCollection<StringElement>(config.Campos);
                Premios = new ObservableCollection<StringElement>(config.Premios);
                Intentos = config.Intentos;
                ImagenInicio = config.ImagenInicio;
                FondoFormulario = config.FondoFormulario;
                FondoRuleta = config.FondoRuleta;
            }
            else
            {
                Campos = new ObservableCollection<StringElement>();
                Premios = new ObservableCollection<StringElement>();
                for (int i = 0; i < 12; i++)
                {
                    Premios.Add(new StringElement("Premio " + (i + 1)));
                }
            }
        }
    }
}
