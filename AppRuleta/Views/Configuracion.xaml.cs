using AppRuleta.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Configuracion.xaml
    /// </summary>
    public partial class Configuracion : Page
    {
        ConfiguracionViewModel viewmodel;

        public Configuracion()
        {
            InitializeComponent();
            Loaded += Configuracion_Loaded;
        }

        private void Configuracion_Loaded(object sender, RoutedEventArgs e)
        {
            viewmodel = DataContext as ConfiguracionViewModel;
            viewmodel.PropertyChanged += Vm_PropertyChanged;
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "Guardado":
                    if(viewmodel.Guardado)
                    {
                        MessageBox.Show("Configuración guardada!");
                    }
                    return;
                case "ErrorIntentos":
                    MessageBox.Show("El número de intentos debe ser mayor a 0!");
                    return;
            }
        }

        private void VolverButton_Click(object sender, RoutedEventArgs e)
        {
            Inicio inicio = new Inicio();
            (Application.Current.MainWindow as MainWindow).Ventana.NavigationService.Navigate(inicio);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void SalirButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SetImagenInicio(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            bool? result = dialog.ShowDialog();
            if(result == true)
            {
                viewmodel.ImagenInicio = dialog.FileName;
            }
        }

        private void SetFondoFormulario(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                viewmodel.FondoFormulario = dialog.FileName;
            }
        }

        private void SetFondoRuleta(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                viewmodel.FondoRuleta = dialog.FileName;
            }
        }
    }
}
