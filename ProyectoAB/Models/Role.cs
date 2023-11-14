using System;
using System.Collections.Generic;

namespace ProyectoAB.Models
{
    public partial class Role
    {
        public Role()
        {
            RolesProyectos = new HashSet<RolesProyecto>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<RolesProyecto> RolesProyectos { get; set; }
    }
}
