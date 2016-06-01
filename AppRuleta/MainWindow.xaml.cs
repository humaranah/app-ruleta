using AppRuleta.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppRuleta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists("config.xml"))
            {
                Inicio inicio = new Inicio();
                Ventana.NavigationService.Navigate(inicio);
            }
            else
            {
                Configuracion configuracion = new Configuracion();
                Ventana.NavigationService.Navigate(configuracion);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F12)
            {
                Configuracion configuracion = new Configuracion();
                Ventana.NavigationService.Navigate(configuracion);
            }
        }
    }
}
