using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroPrestamos.BLL;
using RegistroPrestamos.Entidades;

namespace RegistroPrestamos.UI.Consulta
{
    /// <summary>
    /// Interaction logic for cPersonas.xaml
    /// </summary>
    public partial class cPersonas : Window
    {
        public cPersonas()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Datos.ItemsSource = null;
            var listado = new List<Personas>();

            if (DesdeDate.SelectedDate != null)
            {
                listado = PersonasBLL.GetList(c => c.Fecha.Date >= DesdeDate.SelectedDate);
            }
            else
            {
                listado = PersonasBLL.GetList(c => true);
            }

            if (HastaDate.SelectedDate != null)
            {
                listado = PersonasBLL.GetList(c => c.Fecha.Date <= HastaDate.SelectedDate);
            }
            else
            {
                listado = PersonasBLL.GetList(c => true);
            }
            Datos.ItemsSource = listado;
        }
    }
}