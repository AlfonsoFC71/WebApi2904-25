using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi2904_25.Dta;
using WebApi2904_25.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi2904_25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPuestoController : ControllerBase
    {
        public DatContxt _DatContxt;
        public CPuestoController(DatContxt datContxt) {
            _DatContxt = datContxt;
        }
        // GET: api/<CPuestoController>
        [HttpGet]
        public async Task<List<CPuesto>> Get()
        {
            List <CPuesto> listc = new List<CPuesto>();
            listc = await _DatContxt.CPuestos.FromSql($"EXEC SP_PUESTO @OPC=50").ToListAsync();
            return listc;
        }

        // GET api/<CPuestoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CPuestoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CPuestoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CPuestoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
