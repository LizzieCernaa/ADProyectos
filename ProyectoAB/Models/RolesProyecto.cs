using System;
using System.Collections.Generic;

namespace ProyectoAB.Models
{
    public partial class RolesProyecto
    {
        public int Id { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdRole { get; set; }
        public int? IdColaborador { get; set; }

        public virtual Colaborador? IdColaboradorNavigation { get; set; }
        public virtual Proyecto? IdProyectoNavigation { get; set; }
        public virtual Role? IdRoleNavigation { get; set; }
    }
}
