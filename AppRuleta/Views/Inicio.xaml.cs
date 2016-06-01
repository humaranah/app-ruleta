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
    /// Interaction logic for Inicio.xaml
    /// </summary>
    public partial class Inicio : Page
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            Formulario formulario = new Formulario();
            (Application.Current.MainWindow as MainWindow).Ventana.NavigationService.Navigate(formulario);
        }
    }
}
