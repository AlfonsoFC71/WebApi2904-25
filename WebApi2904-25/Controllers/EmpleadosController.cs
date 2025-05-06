using Microsoft.AspNetCore.Mvc;
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
        public DatContxt _DatContxt;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
