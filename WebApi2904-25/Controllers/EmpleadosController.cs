using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi2904_25.Dta;
using WebApi2904_25.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi2904_25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly DatContxt _DatContxt;
       public EmpleadosController(DatContxt datContxt)
        {
            _DatContxt = datContxt;
        }
        // GET: api/<EmpleadosController>
        [HttpGet]
        public async Task<List<Empleados>> Get()
        {
            List<Empleados> list = new List<Empleados>();
            list = await _DatContxt.Empleados.FromSql($"EXEC SP_T_EMPLEADOS @OPC=54").ToListAsync();
            return list;
        }

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}")]
        public async Task<Empleados> Get(int id)
        {
            List<Empleados> listE = new List<Empleados>();
            Empleados emp = new Empleados();
            try
            {
                listE = await _DatContxt.Empleados.FromSql($"EXEC SP_T_EMPLEADOS @OPC=55, @Id_NumEmp={id}").ToListAsync();
                foreach(Empleados empleados in listE)
                {
                    emp.Id_NumEmp = empleados.Id_NumEmp;
                    emp.Nombre = empleados.Nombre;
                    emp.Apellidos = empleados.Apellidos;
                    emp.Id_Puesto = empleados.Id_Puesto;
                }
            }
            catch(Exception ex)
            {
              Console.WriteLine(ex.Message);
            }
            return emp;
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        public  void Post(Empleados emp)
        {
            try
            {

                    var datos =  _DatContxt.Database.ExecuteSqlRaw("EXEC SP_EMPLEO @Nombre={0},@Apellidos={1},@Id_Puesto={2}", 
                        emp.Nombre,emp.Apellidos,emp.Id_Puesto);

            }catch(TaskCanceledException ex)
            {
                Console.WriteLine(ex);
            }
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("{id}")]
        public void Put(int id, Empleados emp)
        {
            try
            {
                var datos = _DatContxt.Database.ExecuteSqlRaw("EXEC SP_T_EMPLEADOS @OPC={0},@Id_NumEmp={1}, @Nombre={2},@Apellidos={3},@Id_Puesto={4}",
                 2,id, emp.Nombre, emp.Apellidos, emp.Id_Puesto);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var datos = _DatContxt.Database.ExecuteSqlRaw("EXEC SP_T_EMPLEADOS @OPC={0},@Id_NumEmp={1}",
                 3, id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
