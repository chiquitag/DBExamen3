
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DBExamen3.Models;


namespace DBExamen3.Clases
{
    public class clsAdministradorITM
    {
        private DBExamenEntities DBExamen = new DBExamenEntities(); // Es el atributo (Propiedad) para gestionar la conexión a la base de datos
        public AdministradorITM administradorITM { get; set; } //Propiedad para manipular la información en la base de datos: Permite agregar, modificar o eliminar
        public string Insertar()
        {
            try
            {
                DBExamen.AdministradorITMs.Add(administradorITM); //Agregar el objeto administradorITM a la lista de "AdministradoresITM". Todavía no se agrega a la base de datos. Se debe invocar el método SaveChanges()
                DBExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Administrador insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el administrador: " + ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                //Antes de actualizar un elemento (administradorITM), se debe consultar para verificar que exista, y ahí si poderlo actualizar
                AdministradorITM admin = Consultar(administradorITM.idAministradorITM.ToString());


                if (admin == null)
                {
                    return "El administrador con el id ingresado no existe, por lo tanto no se puede actualizar";
                }
                //El administrador existe lo podemos actualizar
                DBExamen.AdministradorITMs.AddOrUpdate(administradorITM); //Actualiza el objeto administradorITM en la lista de "AdministradoresITM". Todavía no se actualiza en la base de datos. Se debe invocar el método SaveChanges()
                DBExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se actualizó el administrador correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el administrador: " + ex.Message;
            }
        }
        public List<AdministradorITM> ConsultarTodos()
        {
            return DBExamen.AdministradorITMs
                .OrderBy(e => e.NombreCompleto) //OrderBy() es una función que permite ordenar los elementos de una lista de acuerdo a un criterio específico. En este caso, se ordena por el nombre completo
                .ToList(); //ToList() es una función que convierte una lista de datos en una lista de objetos
        }
        public AdministradorITM Consultar(string idAdministradorITM)
        {
            try
            {
                if (int.TryParse(idAdministradorITM, out int id))
                {
                    return ConsultarTodos().FirstOrDefault(a => a.idAministradorITM == id);
                }
                throw new ArgumentException("El ID del Administrador no es válido.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el administrador por ID: " + ex.Message);
            }
        }
        public string Eliminar()
        {
            try
            {
                //Antes de eliminar se debe verificar si el administrador existe
                AdministradorITM admin = Consultar(administradorITM.idAministradorITM.ToString());

                if (admin == null)
                {
                    return "El administrador con el id ingresado no existe, por lo tanto no se puede eliminar";
                }
                //El administrador existe lo podemos eliminar. Se elimina el objeto administradorITM que se busca, no el que se envía como parámetro
                DBExamen.AdministradorITMs.Remove(admin); //Eliminar el objeto administrador de la lista de "AdministradoresITM". Todavía no se elimina de la base de datos. Se debe invocar el método SaveChanges()
                DBExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se eliminó el administrador correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el administrador: " + ex.Message;
            }
        }
        public string Eliminar(string idAministradorITM)
        {
            try
            {
                //Antes de eliminar se debe verificar si el administrador existe
                AdministradorITM admin = Consultar(idAministradorITM);
                if (admin == null)
                {
                    return "El administrador con el id ingresado no existe, por lo tanto no se puede eliminar";
                }
                //El administrador existe lo podemos eliminar. Se elimina el objeto administrador que se busca, no el que se envía como parámetro
                DBExamen.AdministradorITMs.Remove(admin); //Eliminar el objeto administrador de la lista de "AdministradoresITM". Todavía no se elimina de la base de datos. Se debe invocar el método SaveChanges()
                DBExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se eliminó el administrador correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el administrador: " + ex.Message;
            }
        }
    }
}