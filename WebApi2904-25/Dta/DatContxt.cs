using Microsoft.EntityFrameworkCore;
using WebApi2904_25.Models;

namespace WebApi2904_25.Dta
{
    public class DatContxt: DbContext

    {
       public DatContxt(DbContextOptions<DatContxt> options) : base(options) { }

        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<CPuesto> CPuestos { get; set; }    
    }
}
