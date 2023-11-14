using System;
using System.Collections.Generic;

namespace ProyectoAB.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            RolesProyectos = new HashSet<RolesProyecto>();
            Tareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFinalizacion { get; set; }
        public int? IdEstado { get; set; }

        public virtual Estado? IdEstadoNavigation { get; set; }
        public virtual ICollection<RolesProyecto> RolesProyectos { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
