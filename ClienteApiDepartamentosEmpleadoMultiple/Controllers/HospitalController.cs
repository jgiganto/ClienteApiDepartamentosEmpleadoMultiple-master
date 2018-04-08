using ClienteApiDepartamentosEmpleadoMultiple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClienteApiDepartamentosEmpleadoMultiple.Controllers
{
    public class HospitalController : Controller
    {
        ModeloHospital modelo;
        public HospitalController()
        {
            this.modelo = new ModeloHospital();
        }
        // GET: Hospital
        public async Task<ActionResult> Departamentos()
        {
            List<Departamentos> departamentos = await modelo.GetDepartamento();
            return View(departamentos);
        }
        public ActionResult Empleados()
        {
            return View();
        }
        ]
        [HttpPost]
        public async Task<ActionResult> Empleados(List<int> departamentos)
        {
            if (departamentos != null)
            {
                List<Empleado> empleados = await modelo.GetEmpleadosDepartamentos(departamentos);              
                return View(empleados);
            }
            else {
                return null;
            }
            
        }
       
        [HttpPost]
         public async Task<ActionResult> IncrementoSalarial(List<int> empno, int incremento)
        {
                List<Empleado> empleados = await modelo.IncrementoSalarial(empno, incremento);
            Response.Redirect("Empleados");
         return RedirectToAction("Departamentos");//ok
          
            //return View(empleados);

        }

    }
}