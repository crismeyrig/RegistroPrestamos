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
using RegistroPrestamos.BLL;
using RegistroPrestamos.Entidades;

namespace RegistroPrestamos.UI.Registro
{
    public partial class rPrestamos:Window
    {
        Prestamos prestamos = new Prestamos();
        public rPrestamos ()
        {
            InitializeComponent();
            DataContext = prestamos;

        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var prestamo= PrestamosBLL.Buscar(int.Parse(PrestamoIdTextBox.Text));

            if(prestamo != null)
            {
                this.prestamos =  prestamo;
            }
            else
            {
                prestamo = new Prestamos();
            }
            DataContext = prestamo;

        }

         private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Contexto context = new Contexto();
        
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
                Refrescar();
            
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
            if(ConceptoTextBox.Text.Length ==0)
            {                
                esValido = true;     
                MessageBox.Show("Transaccion Fallida" , "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);            }
            return esValido;  
        }
        }
    }
        
    
