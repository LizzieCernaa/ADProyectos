using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProyectoAB.Models
{
    public partial class Tarea
    {
        public Tarea()
        {
            Asignaciones = new HashSet<Asignacion>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateOnly? FechaInicio { get; set; }
        public DateOnly? FechaVencimiento { get; set; }
        public int? EstadoId { get; set; }
        public int? ProyectoId { get; set; }
        [JsonIgnore]
        public virtual Estado? Estado { get; set; }
        [JsonIgnore]
        public virtual Proyecto? Proyecto { get; set; }
        [JsonIgnore]
        public virtual ICollection<Asignacion> Asignaciones { get; set; }
    }
}
