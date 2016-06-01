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
    public class FormularioViewModel : ViewModelBase
    {
        private ObservableCollection<Campo> campos;
        private bool vacio;
        private bool guardado;
        private string fondo;

        public RelayCommand Registrar { get; set; }

        public ObservableCollection<Campo> Campos
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

        public bool Vacio
        {
            get
            {
                return vacio;
            }

            set
            {
                vacio = value;
                RaisePropertyChanged();
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

        public FormularioViewModel()
        {
            Registrar = new RelayCommand(delegate { registrar(); });

            if (IsInDesignMode)
            {
                Campos = new ObservableCollection<Campo>();
                for (int i = 0; i < 6; i++)
                {
                    Campos.Add(new Campo()
                    {
                        Nombre = "Campo",
                        Valor = "Valor"
                    });
                }
            }
            else
            {
                Cargar();
            }
        }

        public void Cargar()
        {
            var collection = new ObservableCollection<Campo>();
            if (File.Exists("config.xml"))
            {
                Config config;
                XmlSerializer xs = new XmlSerializer(typeof(Config));
                using (StreamReader sr = new StreamReader("config.xml"))
                {
                    config = xs.Deserialize(sr) as Config;
                }
                foreach (var item in config.Campos)
                {
                    collection.Add(new Campo()
                    {
                        Nombre = item.Value,
                        Valor = ""
                    });
                }
                Fondo = config.FondoFormulario;
            }
            Campos = collection;
        }

        private void registrar()
        {
            foreach (var item in Campos)
            {
                if (string.IsNullOrEmpty(item.Valor))
                {
                    Vacio = true;
                    return;
                }
            }

            var line = "";
            var last = Campos.Last();
            var separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
            foreach (var item in Campos)
            {
                if (!item.Equals(last))
                {
                    line += item.Valor + separator;
                }
                else
                {
                    line += item.Valor;
                }
            }
            using (StreamWriter sw = new StreamWriter("registro.csv", true))
            {
                sw.WriteLine(line);
            }
            Guardado = true;
        }
    }
}
