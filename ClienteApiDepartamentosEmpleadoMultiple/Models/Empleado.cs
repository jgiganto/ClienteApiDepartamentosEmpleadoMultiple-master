using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ClienteApiDepartamentosEmpleadoMultiple.Models
{
    public class Empleado
    {
        [JsonProperty("APELLIDO")]
        public String Apellido { get; set; }
        [JsonProperty("OFICIO")]
        public String Oficio { get; set; }
        [JsonProperty("DEPT_NO")]
        public int Departamento { get; set; }
        [JsonProperty("EMP_NO")]
        public int empno { get; set; }
        [JsonProperty("SALARIO")]
        public int salario { get; set; }

    }
}