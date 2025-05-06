using System.ComponentModel.DataAnnotations;

namespace WebApi2904_25.Models
{
    public class CPuesto
    {
        [Key]
        public int Id_Puesto { get; set; }
        public string Puesto { get; set; }
    }
}
