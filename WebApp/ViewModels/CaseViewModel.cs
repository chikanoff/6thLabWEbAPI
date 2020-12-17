using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class CaseViewModel
    {
        public int Id { get; set; }
        public int AgentId { get; set; }

        public string AgentFullName { get; set; }
        public int PolicyId { get; set; }
        public DateTime PolicyRegisterDate { get; set; }
        public DateTime Date { get; set; }
        public decimal Payment { get; set; }
        public string ConfirmationDocuments { get; set; }
    }
}
