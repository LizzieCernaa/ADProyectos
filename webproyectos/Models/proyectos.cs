using System.ComponentModel.DataAnnotations;

namespace webproyectos.Entidades
{
    public class proyectos
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null;
        public DateTime FechaInicio { get; set; }
        public DateTime Fechafinalizacion { get; set; }
    }
}
