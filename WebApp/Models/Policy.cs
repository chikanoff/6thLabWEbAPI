using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Models
{
    public partial class Policy
    {
        public Policy()
        {
            Cases = new HashSet<Case>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime RegistredAt { get; set; }
        public DateTime Finish { get; set; }
        public int TypeOfInsuranceId { get; set; }

        public virtual Client Client { get; set; }
        public virtual TypesOfinsurance TypeOfInsurance { get; set; }
        public virtual ICollection<Case> Cases { get; set; }
    }
}
