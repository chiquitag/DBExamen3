using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBExamen3.Models
{
    public class LoginRespuesta
    {
        public string Usuario { get; set; }
        public bool Autenticado { get; set; }
        public string Token { get; set; }
        public string Mensaje { get; set; }
    }
}