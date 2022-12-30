using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: EmpleadoController
        [EnableCors("API")]
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();

            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
            //return new string[] { "Leonardo", "Isaac","Jesus" };
        }


        [EnableCors("API")]
        [Route("Get")]
        [HttpGet]
        public IActionResult GetAllEF()
        {
            ML.EntidadFederativa entidadFederativa = new ML.EntidadFederativa();

            ML.Result result = BL.Entidad.GetAllEntidades();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
            
        }

        // GET: EmpleadoController/Details/5
        [HttpGet("GetById/{IdEmpleado}")]
        public IActionResult Get(int IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            
            ML.Result result = BL.Empleado.GetById(IdEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

       

        // POST: EmpleadoController/Create
       
        [HttpPost("add")]
        public IActionResult Post([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("Put")]
        public IActionResult Put([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.UpDate(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }



        // GET: EmpleadoController/Delete/5
        [HttpDelete("Delete")]
        public IActionResult Delete(int IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();

            ML.Result result = BL.Empleado.Delete(IdEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


    }
}
