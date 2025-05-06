using System.ComponentModel.DataAnnotations;

namespace WebApi2904_25.Models
{
    public class Empleados
    {
        [Key]
        public int Id_NumEmp {  get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set;}
        public int Id_Puesto { get; set; }
    }
}
