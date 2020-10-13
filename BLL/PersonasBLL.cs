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

    public class PersonasBLL{

        public static bool Guardar(Personas personas)
        {
            if (!Existe(personas.PersonaId)) { return Insertar(personas); }
            else { return Modificar(personas); }
        }

      public static bool Eliminar(int Id)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                var Personas = datos.Personas.Find(Id); 
                if(Personas!= null)
                {
                    datos.Personas.Remove(Personas);
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

        private static bool Insertar(Personas Personas)
        {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                if(datos.Personas.Add(Personas) != null) { esOk = datos.SaveChanges() > 0; }
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
                esOk = datos.Personas.Any(e => e.PersonaId == Id);
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

            private static bool Modificar(Personas Personas)
            {
            Contexto datos = new Contexto();
            bool esOk = false;

            try
            {
                datos.Entry(Personas).State = EntityState.Modified;
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

         public static Personas Buscar(int Id)
        {
            Contexto datos = new Contexto();
            Personas Persona= new Personas();

            try
            {
                Persona = datos.Personas.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.Dispose();
            }
            return Persona;
        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> criterio)
        {                        
            List<Personas> lista = new List<Personas>(); 
            Contexto contexto = new Contexto();
            try
            {                
                //obtener la lista y filtrarla segun el criterio recibido por parametro  
               lista = contexto.Personas.Where(criterio).ToList();
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