using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProyectoAB.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Proyectos = new HashSet<Proyecto>();
            Tareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Proyecto> Proyectos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
