using System;
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
        [HttpGet]
        public async Task<dynamic> GetAllElevators(){

            var elevators = await _context.elevators.ToListAsync();
            
            var i = 0;
            
            var numbers = new List<Int64>(){};
            foreach(Elevator elevator in elevators)
            {
                i++;
            }
            numbers.Add(i);
            
            return numbers;
        }

        [HttpGet("status/{status}")]
        public IEnumerable<Elevator> GetIntervention(string status)
        {   
            IQueryable<Elevator> elevators = from l in _context.elevators
                                             where l.status == status
                                             select l;
 
            return elevators.ToList();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> GetElevators(long id)
        {

            var elevator = await _context.elevators.FindAsync(id);
            //if no elevetor is returned 
            if (elevator == null)
            {
                return NotFound();
            }

            return elevator;
        }
    }

}






        

  