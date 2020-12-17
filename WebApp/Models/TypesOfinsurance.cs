using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Models
{
    public partial class TypesOfinsurance
    {
        public TypesOfinsurance()
        {
            Policies = new HashSet<Policy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Payment { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
