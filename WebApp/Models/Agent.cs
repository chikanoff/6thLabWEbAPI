using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Models
{
    public partial class Agent
    {
        public Agent()
        {
            Cases = new HashSet<Case>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsWorker { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public decimal Commision { get; set; }
        public string Contract { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}
