using System;
using System.Collections.Generic;

namespace ProyectoAB.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FristName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Branch { get; set; } = null!;
        public string Age { get; set; } = null!;
    }
}
