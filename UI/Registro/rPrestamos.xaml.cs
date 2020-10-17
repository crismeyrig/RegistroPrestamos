using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using RegistroPrestamos.BLL;
using RegistroPrestamos.DAL;
using RegistroPrestamos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace RegistroPrestamos.UI.Registro
{
    public partial class rPrestamos : Window
    {
        private Prestamos prestamos = new Prestamos();
        public rPrestamos()
        {
            InitializeComponent();
            this.DataContext = prestamos;

            PersonaIdComboBox.ItemsSource = PersonasBLL.GetPersonas();
            PersonaIdComboBox.SelectedValuePath = "PersonaId";
            PersonaIdComboBox.DisplayMemberPath = "Nombres";


        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = prestamos;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Prestamos encontrado = PrestamosBLL.Buscar(Utilidades.ToInt(PrestamoIdTextBox.Text));

            if (encontrado != null)
            {
                this.prestamos = encontrado;
                Cargar();
            }
            else
            {
                this.prestamos = new Prestamos();
                this.DataContext = this.prestamos;
                MessageBox.Show("Este prestamo no fue encontrado.\n\nAsegurate de que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Refrescar();
            }

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var proceso = PrestamosBLL.Guardar(prestamos);

            if (proceso == true)
            {
                Refrescar();
                MessageBox.Show("Guardado Correctamente.", "Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Guardado Fallido", "Incompleto", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PrestamosBLL.Eliminar(int.Parse(PrestamoIdTextBox.Text)))
            {
                Refrescar();
                MessageBox.Show("Datos Eliminados", "Completo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar los datos", "Incompleto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Refrescar();
        }

        private void Refrescar()
        {
            this.prestamos = new Prestamos();
            this.DataContext = prestamos;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Refrescar();
        }


        private bool Validar()
        {
            bool esValido = true;
            if (ConceptoTextBox.Text.Length == 0)
            {
                esValido = true;

                MessageBox.Show("Transaccion Fallida", "Por favor indiqueun concepto", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (MontoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida, Debe introducir un monto", "Fallo");
            }
            return esValido;
        }
        /*private void mostrarDatos(){
            PrestamoIdTextBox.Text = prestamos.PrestamoId.ToString();
           // FechaDatePicker.Text = prestamos.Fecha; 
            ConceptoTextBox.Text = prestamos.Concepto;
            MontoTextBox.Text = prestamos.Monto.ToString("N2");
            BalanceTextBox.Text = prestamos.Balance.ToString("N2"); 
            PersonaIdComboBox.SelectedValue= prestamos.PersonaId;
        }*/

    }


}


