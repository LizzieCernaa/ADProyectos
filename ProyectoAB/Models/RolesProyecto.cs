using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProyectoAB.Models
{
    public partial class RolesProyecto
    {
        public int Id { get; set; }
        public int? ProyectoId { get; set; }
        public int? RoleId { get; set; }
        public int? ColaboradorId { get; set; }

        [JsonIgnore]
        public virtual Colaborador? Colaborador{ get; set; }
        [JsonIgnore]
        public virtual Proyecto? Proyecto{ get; set; }
        [JsonIgnore]
        public virtual Roles? Role { get; set; }
    }
}
