using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ClienteApiDepartamentosEmpleadoMultiple.Models
{
    public class Departamentos
    {
        [JsonProperty("DEPT_NO")]
        public int Numero { get; set; }
        [JsonProperty("DNOMBRE")]
        public String Nombre { get; set; }
        [JsonProperty("LOC")]
        public String Localidad { get; set; }

    }
}