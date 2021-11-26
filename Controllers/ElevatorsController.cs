using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RocketApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public ElevatorsController(ApplicationContext context)
        {
            _context = context;
        }
        // [HttpGet("{all}")]
        // public async Task<ActionResult<IEnumerable<Elevator>>> GetAllElevators()
        // {
        //     return await _context.elevators
        //     .ToListAsync();
        // }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevator>>> getElevators()
        {
            return await _context.elevators.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> GetElevatorId(long id)
        {
            var elevator = await _context.elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator;
        }


        
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetElevatorStatus(long id)
        {
            var elevator = await _context.elevators.FindAsync(id);
            if (elevator == null)
            {
                return NotFound();
            }
            return elevator.Status;
        }
       
        [HttpGet("Offline")]
        public object GetElevatorsOffline()
        {
            return _context.elevators
                  .Where(elevator => elevator.Status == "offline" || elevator.Status == "maintenance")
                  .Select(elevator => new { elevator.Id, elevator.Status });

        }

        [HttpGet("update/{id}/{status}")]
        public async Task<dynamic> test(string status, long id)
        {
            var elevator = await _context.elevators.FindAsync(id);
            
            elevator.Status = status;
            await _context.SaveChangesAsync();         

            return elevator;
        }
        
        
        
    }

}






        

  
