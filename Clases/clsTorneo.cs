
using DBExamen3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DBExamen3.Clases
{
    public class clsTorneo
    {
        private DBExamenEntities DBExamen = new DBExamenEntities(); // Es el atributo (Propiedad) para gestionar la conexión a la base de datos
        public Torneo torneo { get; set; } //Propiedad para manipular la información en la base de datos: Permite agregar, modificar o eliminar
        public string Insertar()
        {
            try
            {
                DBExamen.Torneos.Add(torneo); //Agregar el objeto torneo a la lista de "Torneos". Todavía no se agrega a la base de datos. Se debe invocar el método SaveChanges()
                DBExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Torneo insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el torneo: " + ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                //Antes de actualizar un elemento (torneo), se debe consultar para verificar que exista, y ahí si poderlo actualizar
                Torneo tor = ConsultarPorId(torneo.idTorneos.ToString());
                if (tor == null)
                {
                    return "El torneo con el id ingresado no existe, por lo tanto no se puede actualizar";
                }
                //El torneo existe lo podemos actualizar
                DBExamen.Torneos.AddOrUpdate(torneo); //Actualiza el objeto torneo en la lista de "Torneos". Todavía no se actualiza en la base de datos. Se debe invocar el método SaveChanges()
                DBExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se actualizó el torneo correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el torneo: " + ex.Message;
            }
        }
        public List<Torneo> ConsultarTodos()
        {
            return DBExamen.Torneos
                .OrderBy(e => e.FechaTorneo) //OrderBy() es una función que permite ordenar los elementos de una lista de acuerdo a un criterio específico. En este caso, se ordena por la fecha del torneo
                .ToList(); //ToList() es una función que convierte una lista de datos en una lista de objetos
        }
        public Torneo ConsultarPorId(string idTorneos)
        {
            try
            {
                if (int.TryParse(idTorneos, out int idTorneo))
                {
                    return ConsultarTodos().FirstOrDefault(t => t.idTorneos == idTorneo);
                }
                throw new ArgumentException("El ID del torneo no es válido.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el torneo por ID: " + ex.Message);
            }
        }

        public Torneo ConsultarPorNombre(string nombre)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                    throw new ArgumentException("El nombre del torneo no puede estar vacío.");

                return ConsultarTodos().FirstOrDefault(t => t.NombreTorneo == nombre);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el torneo por nombre: " + ex.Message);
            }
        }

        public Torneo ConsultarPorFecha(string fecha)
        {
            try
            {
                if (!DateTime.TryParse(fecha, out DateTime fechaParsed))
                    throw new ArgumentException("La fecha ingresada no es válida.");

                return ConsultarTodos().FirstOrDefault(t => t.FechaTorneo.Date == fechaParsed.Date);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el torneo por fecha: " + ex.Message);
            }
        }

        public Torneo ConsultarPorTipo(string tipo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tipo))
                    throw new ArgumentException("El tipo de torneo no puede estar vacío.");

                return ConsultarTodos().FirstOrDefault(t => t.TipoTorneo == tipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el torneo por tipo: " + ex.Message);
            }
        }
        public string Eliminar()
        {
            try
            {
                //Antes de eliminar se debe verificar si el torneo existe
                Torneo tor = ConsultarPorId(torneo.idTorneos.ToString());

                if (tor == null)
                {
                    return "El torneo con el id ingresado no existe, por lo tanto no se puede eliminar";
                }
                //El torneo existe lo podemos eliminar. Se elimina el objeto torneo que se busca, no el que se envía como parámetro
                DBExamen.Torneos.Remove(tor); //Eliminar el objeto torneo de la lista de "Torneos". Todavía no se elimina de la base de datos. Se debe invocar el método SaveChanges()
                DBExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se eliminó el torneo correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el torneo: " + ex.Message;
            }
        }
        public string Eliminar(string idTorneos)
        {
            try
            {
                //Antes de eliminar se debe verificar si el torneo existe
                Torneo tor = ConsultarPorId(torneo.idTorneos.ToString());
                if (tor == null)
                {
                    return "El torneo con el id ingresado no existe, por lo tanto no se puede eliminar";
                }
                //El torneo existe lo podemos eliminar. Se elimina el objeto torneo que se busca, no el que se envía como parámetro
                DBExamen.Torneos.Remove(tor); //Eliminar el objeto torneo de la lista de "Torneos". Todavía no se elimina de la base de datos. Se debe invocar el método SaveChanges()
                DBExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se eliminó el torneo correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el torneo: " + ex.Message;
            }
        }
    }
}