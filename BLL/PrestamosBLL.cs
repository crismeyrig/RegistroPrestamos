using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using RegistroPrestamos.Entidades;

namespace RegistroPrestamos.BLL
{

    public class PrestamosBLL{

        public static bool Guardar(Prestamos Prestamo)
        {
            if (!Existe(Prestamo.PrestamoId)) { return Insertar(Prestamo); }
            else { return Modificar(Prestamo); }
        }

      public static bool Eliminar(int Id)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                var Prestamos = datos.Prestamos.Find(Id); 
                if(Prestamos!= null)
                {
                    datos.Prestamos.Remove(Prestamos);
                    esOk = datos.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;

        }

        private static bool Insertar(Prestamos Prestamo)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                if(datos.Prestamos.Add(Prestamo) != null) { esOk = datos.SaveChanges() > 0; }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;
        }

        public static bool Existe(int Id)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                esOk = datos.Prestamos.Any(e => e.PrestamoId == Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;
        }

            private static bool Modificar(Prestamos Prestamo)
            {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                datos.Entry(Prestamo).State = EntityState.Modified;
                esOk = datos.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return esOk;
        }

        public static Prestamos Buscar(int Id)
        {
            Contexto datos = new Contexto();
            Prestamos Prestamo= new Prestamos();

            try
            {
                Prestamo = datos.Prestamos.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return Prestamo;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {                        
            List<Prestamos> lista = new List<Prestamos>(); 
            Contexto contexto = new Contexto();
            try
            {                
                //obtener la lista y filtrarla segun el criterio recibido por parametro  
               lista = contexto.Prestamos.Where(criterio).ToList();
            }          
          catch(Exception){ 

           throw;           
        }           
        
         finally
         {   
              contexto.Dispose(); 
         }            
         
            return lista; 
        }


        
    }
 
}

