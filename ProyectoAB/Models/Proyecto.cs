using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        public int? EstadoId { get; set; }

        [JsonIgnore]
        public virtual Estado? Estado { get; set; }
        [JsonIgnore]
        public virtual ICollection<RolesProyecto> RolesProyectos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
