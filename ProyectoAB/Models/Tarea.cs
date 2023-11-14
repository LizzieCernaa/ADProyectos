using System;
using System.Collections.Generic;

namespace ProyectoAB.Models
{
    public partial class Tarea
    {
        public Tarea()
        {
            Asignaciones = new HashSet<Asignacione>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateOnly? FechaInicio { get; set; }
        public DateOnly? FechaVencimiento { get; set; }
        public int? IdEstado { get; set; }
        public int? IdProyecto { get; set; }

        public virtual Estado? IdEstadoNavigation { get; set; }
        public virtual Proyecto? IdProyectoNavigation { get; set; }
        public virtual ICollection<Asignacione> Asignaciones { get; set; }
    }
}
