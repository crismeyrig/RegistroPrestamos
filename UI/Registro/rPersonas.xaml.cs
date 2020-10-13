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
    public partial class rPersonas:Window
    {
        Personas persona = new Personas();
        public rPersonas ()
        {
            InitializeComponent();
            DataContext = persona;

        }
        private void Limpiar()
        {          
            this.persona = new Personas();
            this.DataContext= persona;
        }
        private bool Validar()
        {  
            bool esValido = true;
            if(NombresTextBox.Text.Length ==0)
            {                
                esValido = true;  
                 MessageBox.Show("Transaccion Fallida" , "Fallo",  MessageBoxButton.OK, MessageBoxImage.Warning);  
                           
            }
            return esValido; 
            }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {           
             var personas = PersonasBLL.Buscar(Utilidades.ToInt(PersonaIdTextBox.Text));
            if(persona != null)
            {                   
                this.persona = personas; 
            }           
            else
            {      
                this.persona = new Personas();  
            }            
                this.DataContext = this.persona; 
            }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();       
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {  
                if(!Validar())
                {    
                
                    return;  
                }           
                 var paso = PersonasBLL.Guardar(persona);
                if(paso)
                {              
                    Limpiar();  
                    MessageBox.Show("Transaccion exitosa!" , "Exito", MessageBoxButton.OK, MessageBoxImage.Information); 
                }           
                else
                {     
                    MessageBox.Show("Transaccion Fallida", "Fallo",  MessageBoxButton.OK, MessageBoxImage.Error); 
                }      
             }
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {        
                if(PersonasBLL.Eliminar(Utilidades.ToInt(PersonaIdTextBox.Text)))
                {
                    Limpiar(); 
                    MessageBox.Show("Registro eliminado!" , "Exito" , MessageBoxButton.OK, MessageBoxImage.Information); 
                }            
                else
                {      
                    MessageBox.Show("No fue posible eliminar", "Fallo",MessageBoxButton.OK, MessageBoxImage.Error);   
                }       
             }
    }   }