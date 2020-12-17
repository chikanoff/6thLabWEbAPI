using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApp.Data;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly courseworkDbContext _context;

        public CasesController(courseworkDbContext context)
        {
            _context = context;
        }

        // GET: api/Cases
        [HttpGet]
        public List<CaseViewModel> GetCases()
        {
            var cases = _context.Cases.Include(x => x.Agent).Include(x => x.Policy).Take(20).Select(x =>
                new CaseViewModel
                {
                    Id = x.Id,
                    AgentFullName = x.Agent.Name,
                    AgentId = x.AgentId,
                    ConfirmationDocuments = x.ConfirmationDocuments,
                    Date = x.Date,
                    Payment = x.Payment,
                    PolicyId = x.PolicyId,
                    PolicyRegisterDate = x.Policy.RegistredAt
                }
                );
            return cases.ToList();
        }
        [HttpGet("agents")]
        public IEnumerable<Agent> GetAgents()
        {
            return _context.Agents.ToList();
        }
        [HttpGet("policies")]
        public IEnumerable<Policy> GetPolicies()
        {
            return _context.Policies.ToList();
        }

        // GET: api/Cases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Case>> GetCase(int id)
        {
            var @case = await _context.Cases.FindAsync(id);

            if (@case == null)
            {
                return NotFound();
            }

            return @case;
        }

        // PUT: api/Cases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public IActionResult Put([FromBody] Case casee)
        {
            if (casee == null)
            {
                return BadRequest();
            }
            if (!_context.Cases.Any(x => x.Id == casee.Id))
            {
                return NotFound();
            }

            _context.Update(casee);
            _context.SaveChanges();

            casee.Agent = _context.Agents.FirstOrDefault(x => x.Id == casee.AgentId);
            casee.Policy = _context.Policies.FirstOrDefault(x => x.Id == casee.PolicyId);
            CaseViewModel caseViewModel = new CaseViewModel
            {
                Id = casee.Id,
                AgentFullName = casee.Agent.Name,
                AgentId = casee.AgentId,
                ConfirmationDocuments = casee.ConfirmationDocuments,
                Date = casee.Date,
                Payment = casee.Payment,
                PolicyId = casee.PolicyId,
                PolicyRegisterDate = casee.Policy.RegistredAt
            };
            return Ok(caseViewModel);
        }

        // POST: api/Cases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Post([FromBody] Case casee)
        {
            if (casee == null)
            {
                return BadRequest();
            }

            _context.Cases.Add(casee);
            _context.SaveChanges();
            return Ok(casee);
        }

        // DELETE: api/Cases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCase(int id)
        {
            var @case = await _context.Cases.FindAsync(id);
            if (@case == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(@case);
            await _context.SaveChangesAsync();

            return Ok(@case);
        }

        private bool CaseExists(int id)
        {
            return _context.Cases.Any(e => e.Id == id);
        }
    }
}
