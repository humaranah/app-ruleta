using AppRuleta.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppRuleta.Views
{
    /// <summary>
    /// Interaction logic for Formulario.xaml
    /// </summary>
    public partial class Formulario : Page
    {
        FormularioViewModel viewmodel;

        public Formulario()
        {
            InitializeComponent();
            Loaded += Formulario_Loaded;
        }

        private void Viewmodel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "Vacio":
                    if(viewmodel.Vacio)
                    {
                        MessageBox.Show("Debes llenar todos los campos para participar!");
                    }
                    return;
                case "Guardado":
                    Ruleta ruleta = new Ruleta();
                    (Application.Current.MainWindow as MainWindow).Ventana.NavigationService.Navigate(ruleta);
                    return;
            }
        }

        private void Formulario_Loaded(object sender, RoutedEventArgs e)
        {
            viewmodel = DataContext as FormularioViewModel;
            viewmodel.PropertyChanged += Viewmodel_PropertyChanged;
            viewmodel.Cargar();
            if(viewmodel.Campos.Count() == 0)
            {
                Ruleta ruleta = new Ruleta();
                (Application.Current.MainWindow as MainWindow).Ventana.NavigationService.Navigate(ruleta);
            }
        }
    }
}
