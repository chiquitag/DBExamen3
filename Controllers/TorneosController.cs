
using DBExamen3.Clases;
using DBExamen3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DBExamen3.Controllers
{
    [RoutePrefix("api/Torneos")]
    //[Authorize]
    public class TorneosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Torneo> ConsultarTodos()
        {
            clsTorneo Torneo = new clsTorneo();
            return Torneo.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXidTorneos")]
        public Torneo ConsultarXidTorneos(string idTorneos)
        {
            clsTorneo Torneo = new clsTorneo();
            return Torneo.ConsultarPorId(idTorneos);
        }

        [HttpGet]
        [Route("ConsultarXNombreTorneo")]
        public Torneo ConsultarXNombreTorneo(string NombreTorneo)
        {
            clsTorneo Torneo = new clsTorneo();
            return Torneo.ConsultarPorNombre(NombreTorneo);
        }

        [HttpGet]
        [Route("ConsultarXFechaTorneo")]
        public Torneo ConsultarXFechaTorneo(string FechaTorneo)
        {
            clsTorneo Torneo = new clsTorneo();
            return Torneo.ConsultarPorFecha(FechaTorneo);
        }

        [HttpGet]
        [Route("ConsultarXTipoTorneo")]
        public Torneo ConsultarXTipoTorneo(string TipoTorneo)
        {
            clsTorneo Torneo = new clsTorneo();
            return Torneo.ConsultarPorTipo(TipoTorneo);
        }



        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Torneo torneo)
        {
            clsTorneo Torneo = new clsTorneo();
            Torneo.torneo = torneo;
            return Torneo.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Torneo torneo)
        {
            clsTorneo Torneo = new clsTorneo();
            Torneo.torneo = torneo;
            return Torneo.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Torneo torneo)
        {
            clsTorneo Torneo = new clsTorneo();
            Torneo.torneo = torneo;
            return Torneo.Eliminar();
        }

        [HttpDelete]
        [Route("EliminarXidTorneos")]
        public string EliminarXidTorneos(string idTorneos)
        {
            clsTorneo Torneo = new clsTorneo();
            return Torneo.Eliminar(idTorneos);
        }
    }
}
