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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AppRuleta.Views
{
    /// <summary>
    /// Interaction logic for Ruleta.xaml
    /// </summary>
    public partial class Ruleta : Page
    {
        Storyboard storyboard;
        RuletaViewModel viewmodel;
        int intentos;

        public Ruleta()
        {
            InitializeComponent();
            viewmodel = DataContext as RuletaViewModel;
            viewmodel.PropertyChanged += Viewmodel_PropertyChanged;
            intentos = viewmodel.Intentos;
            Loaded += Ruleta_Loaded;
        }

        private void Viewmodel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "Premio":
                    girarRuleta();
                    return;
            }
        }

        private void Ruleta_Loaded(object sender, RoutedEventArgs e)
        {
            viewmodel.Cargar();
        }

        private void girarRuleta()
        {
            BotonGirar.IsEnabled = false;
            storyboard = ruleta.Resources["animacion"] as Storyboard;
            storyboard.Begin(ruleta, true);
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            MessageBox.Show("Felicidades!\nHas ganado: " + viewmodel.Premios[viewmodel.Premio] + "!");
            viewmodel.Intentos = --intentos;
            if(intentos < 1)
            {
                MessageBox.Show("Gracias por participar!");
                Inicio inicio = new Inicio();
                (Application.Current.MainWindow as MainWindow).Ventana.NavigationService.Navigate(inicio);
            }
            BotonGirar.IsEnabled = true;
        }
    }
}
