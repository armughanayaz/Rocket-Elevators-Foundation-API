using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RocketApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public InterventionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/interventions/pendinginterventions
        [HttpGet("pendinginterventions")]
        public async Task<ActionResult<List<Intervention>>> PendingInterventions()
        {
            return await _context.interventions.Where(b => (b.start_date == null && b.status == "Pending")).ToListAsync();
        }

          // Put: api/interventions/updatetoinprogress/id
        [HttpPut("updatetoinprogress/{id}")]
        public async Task<ActionResult<Intervention>> InterventionStatusInProgress(long id,  Intervention intervention)
     {
            var i = await _context.interventions.FindAsync(id);

            if (i == null) {
                return NotFound();
            }
            i.status = intervention.status;
            DateTime currentDate = DateTime.Now;
            i.start_date = currentDate;


            try
          {
                await _context.SaveChangesAsync();
          } 
          catch (DbUpdateConcurrencyException)
               {
                throw;
            }
            return i;
          }
        // Put: api/interventions/updatetocompleted/id
        [HttpPut("updatetocompleted/{id}")]
        public async Task<ActionResult<Intervention>> InterventionStatusCompleted(long id, Intervention intervention)
               {
            var i = await _context.interventions.FindAsync(id);
            i.status = intervention.status;

            DateTime currentDate = DateTime.Now;
            i.start_date = currentDate;

            try 
{
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) 
{
                throw;
            }
            return i;
        }
    }
}