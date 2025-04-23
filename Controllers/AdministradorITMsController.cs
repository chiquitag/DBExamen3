using DBExamen3.Models;
using DBExamen3.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DBExamen3.Controllers
{
    [RoutePrefix("api/AdministradorITMs")]
    [Authorize]
    public class AdministradorITMController : ApiController
    {
        //GET: Se utiliza para consultar información, no se debe modificar la base de datos
        //POST: Se utiliza para insertar información en la base de datos
        //PUT: Se utiliza para modificar (Actualizar) información en la base de datos
        //DELETE: Se utiliza para eliminar información en la base de datos
        [HttpGet] //Es el servicio que se va a exponer: GET, POST, PUT, DELETE
        [Route("ConsultarTodos")] //Es el nombre de la funcionalidad que se va a ejecutar
        public List<AdministradorITM> ConsultarTodos()
        {
            //Se crea una instancia de la clase clsAdministradorITM
            clsAdministradorITM AdministradorITM = new clsAdministradorITM();
            //Se invoca el método ConsultarTodos() de la clase clsAdministradorITM
            return AdministradorITM.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXidAministradorITM")]
        public AdministradorITM ConsultarXidAministradorITM(string idAministradorITM)
        {
            //Se crea una instancia de la clase clsAdministradorITM
            clsAdministradorITM AdministradorITM = new clsAdministradorITM();
            return AdministradorITM.Consultar(idAministradorITM);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] AdministradorITM administradorITM)
        {
            //Se crea una instancia de la clase clsAdministradorITM
            clsAdministradorITM AdministradorITM = new clsAdministradorITM();
            //Se pasa la propiedad administradorITM al objeto de la clase clsAdministradorITM
            AdministradorITM.administradorITM = administradorITM;
            //Se invoca el método insertar
            return AdministradorITM.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] AdministradorITM administradorITM)
        {
            //Se crea una instancia de la clase clsAdministradorITM
            clsAdministradorITM AdministradorITM = new clsAdministradorITM();
            AdministradorITM.administradorITM = administradorITM;
            return AdministradorITM.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] AdministradorITM administradorITM)
        {
            //Se crea una instancia de la clase clsAdministradorITM
            clsAdministradorITM AdministradorITM = new clsAdministradorITM();
            AdministradorITM.administradorITM = administradorITM;
            return AdministradorITM.Eliminar();
        }

        [HttpDelete]
        [Route("EliminarXidAministradorITM")]
        public string EliminarXidAministradorITM(string idAministradorITM)
        {
            //Se crea una instancia de la clase clsAdministradorITM
            clsAdministradorITM AdministradorITM = new clsAdministradorITM();
            return AdministradorITM.Eliminar(idAministradorITM);
        }
    }
}
