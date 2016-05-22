using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRuleta.ViewModel
{
    public class ConfiguracionViewModel : ViewModelBase
    {
        private ObservableCollection<string> campos;
        private ObservableCollection<string> premios;
        private int intentos;

        public RelayCommand AgregarCampo { get; set; }
        public RelayCommand<string> BorrarCampo { get; set; }

        public ObservableCollection<string> Campos
        {
            get
            {
                return campos;
            }

            set
            {
                if(campos != value)
                {
                    campos = value;
                    RaisePropertyChanged("Campos");
                }
            }
        }

        public ObservableCollection<string> Premios
        {
            get
            {
                return premios;
            }

            set
            {
                if(premios != value)
                {
                    premios = value;
                    RaisePropertyChanged("Premios");
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
                if(intentos != value)
                {
                    intentos = value;
                    RaisePropertyChanged("Intentos");
                }
            }
        }

        public ConfiguracionViewModel()
        {
            Campos = new ObservableCollection<string>();
            Premios = new ObservableCollection<string>(Enumerable.Repeat("", 12));
            Intentos = new int();

            AgregarCampo = new RelayCommand(() => { Campos.Add(""); });
            BorrarCampo = new RelayCommand<string>((s) => { Campos.Remove(s); });

            if (IsInDesignMode)
            {
                for (int i = 0; i < 5; i++)
                {
                    Campos.Add("Campo de prueba");
                }
                for (int i = 0; i < 12; i++)
                {
                    Premios[i] = "Premio";
                }
                Intentos = 3;
            }
        }
    }
}
