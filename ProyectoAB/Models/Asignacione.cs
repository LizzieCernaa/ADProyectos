using System;
using System.Collections.Generic;

namespace ProyectoAB.Models
{
    public partial class Asignacione
    {
        public int Id { get; set; }
        public int? IdTarea { get; set; }
        public int? IdColaborador { get; set; }

        public virtual Colaboradore? IdColaboradorNavigation { get; set; }
        public virtual Tarea? IdTareaNavigation { get; set; }
    }
}
