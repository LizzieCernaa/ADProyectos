using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProyectoAB.Models
{
    public partial class Asignacion
    {
        public int Id { get; set; }
        public int? TareaId { get; set; }
        public int? ColaboradorId { get; set; }

        [JsonIgnore]
        public virtual Colaborador? Colaborador { get; set; }
        [JsonIgnore]
        public virtual Tarea? Tarea { get; set; }
    }
}
