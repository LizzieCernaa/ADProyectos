using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProyectoAB.Models
{
    public partial class Colaborador
    {
        public Colaborador()
        {
            Asignaciones = new HashSet<Asignacion>();
            RolesProyectos = new HashSet<RolesProyecto>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Asignacion> Asignaciones { get; set; }
        [JsonIgnore]
        public virtual ICollection<RolesProyecto> RolesProyectos { get; set; }
    }
}
