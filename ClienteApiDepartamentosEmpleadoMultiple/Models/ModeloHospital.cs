using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ClienteApiDepartamentosEmpleadoMultiple.Models
{
    public class ModeloHospital
    {
        Uri urlapi;
        MediaTypeWithQualityHeaderValue media;
        public ModeloHospital()
        {
            this.urlapi = new Uri("http://localhost:52896/");
            media = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Departamentos>> GetDepartamento()
        {
            using(HttpClient cliente = new HttpClient())
            {
                String peticion = "api/MostrarDepartamentos";
                cliente.BaseAddress = this.urlapi;
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(media);
                HttpResponseMessage respuesta = await cliente.GetAsync(peticion);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Departamentos> departamentos =
                        await respuesta.Content.ReadAsAsync<List<Departamentos>>();
                    return departamentos;
                }
                else
                {
                    return null;
                }

            }
        }

        public async Task<List<Empleado>> GetEmpleadosDepartamentos(List<int> departamentos)
        {
            using (HttpClient cliente = new HttpClient())
            {
                //localhost:52896/api/EmpleadosDept/?deptnos=20&deptnos=30
                String peticion = "api/EmpleadosDept?";
                String datos = "";
                foreach(var deptno in departamentos)
                {
                    datos += "deptnos=" + deptno + "&";
                }
                datos += datos.Trim('&');//elimina el ultimo & del texto
                peticion += datos;//concateno la peticion
                cliente.BaseAddress = this.urlapi;
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(media);
                HttpResponseMessage respuesta =
                    await cliente.GetAsync(peticion);
                if(respuesta.IsSuccessStatusCode)
                {
                    List<Empleado> lista =
                        await respuesta.Content.ReadAsAsync<List<Empleado>>();
                    return lista;                    
                }
                else
                {
                    return null;
                }
            }
        }

        //http:/localhost:52896/api/Incremento?empno=7322&incremento=11
         

        public async Task<List<Empleado>> IncrementoSalarial(List<int> empno,int incremento)
        {
            using (HttpClient cliente = new HttpClient())
            {
                String peticion = "api/Incremento?";
                String datos = "";

                foreach(var noemp in empno)
                {
                    datos += "empno=" + noemp + "&";
                }
                peticion += datos;
                peticion += "incremento=" + incremento;
                cliente.BaseAddress = this.urlapi;
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(media);

                List<Empleado> em = new List<Empleado>();
                var jsonstring = JsonConvert.SerializeObject(em);

                HttpResponseMessage respuesta =
                       await cliente.PostAsync(peticion, new StringContent(jsonstring));

                if (respuesta.IsSuccessStatusCode)
                {
                    List<Empleado> lista =
                        await respuesta.Content.ReadAsAsync<List<Empleado>>();
                    return lista;
                }
                else
                {
                    return null;
                }

            }
        }

    }
}