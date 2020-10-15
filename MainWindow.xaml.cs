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
using RegistroPrestamos.UI.Consulta;
using RegistroPrestamos.UI.Registro;

namespace RegistroPrestamos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RegistrosPersonasButton_Click(object sender, RoutedEventArgs e)
        {
            rPersonas rPersonas1 = new rPersonas();
            rPersonas1.Show();

        }
        private void RegistrosPrestamosButton_Click(object sender, RoutedEventArgs e)
        {
            rPrestamos rPrestamo = new rPrestamos();
            rPrestamo.Show();
        }

        private void ConsultasPersonasButton_Click(object sender, RoutedEventArgs e)
        {
            cPersonas cPersona = new cPersonas();
            cPersona.Show();
        }

        private void ConsultasPrestamosButton_Click(object sender, RoutedEventArgs e)
        {
            cPrestamos cPrestamo = new cPrestamos();
            cPrestamo.Show();
        }

         private void RegistrosMorasButton_Click(object sender, RoutedEventArgs e)
        {
           rMoras ventana = new rMoras();
           ventana.Show();

        }
        
        private void ConsultasMorasButton_Click(object sender, RoutedEventArgs e)
        {

           

        }
        private void AyudaMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
