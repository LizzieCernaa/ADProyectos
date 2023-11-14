using System;
using System.Collections.Generic;

namespace ProyectoAB.Models
{
    public partial class Colaboradore
    {
        public Colaboradore()
        {
            Asignaciones = new HashSet<Asignacione>();
            RolesProyectos = new HashSet<RolesProyecto>();
        }

        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }

        public virtual ICollection<Asignacione> Asignaciones { get; set; }
        public virtual ICollection<RolesProyecto> RolesProyectos { get; set; }
    }
}
