using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProyectoAB.Models
{
    public partial class Roles
    {
        public Roles()
        {
            RolesProyectos = new HashSet<RolesProyecto>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<RolesProyecto> RolesProyectos { get; set; }
    }
}
