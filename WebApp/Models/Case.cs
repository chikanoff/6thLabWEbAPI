using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Models
{
    public partial class Case
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int PolicyId { get; set; }
        public DateTime Date { get; set; }
        public decimal Payment { get; set; }
        public string ConfirmationDocuments { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Policy Policy { get; set; }
    }
}
