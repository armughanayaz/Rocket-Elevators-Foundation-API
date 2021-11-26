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

    public class BatteriesController : ControllerBase
    {
        private readonly ApplicationContext _context;


        public BatteriesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battery>>> Getbatteries()
        {
            return await _context.batteries
            .ToListAsync();
        }
        


        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetBatteryStatus(long id)
        {
            var battery = await _context.batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery.Status;
        }

        [HttpGet("update/{id}/{status}")]
        public async Task<dynamic> test(string status, long id)
        {
            var battery = await _context.batteries.FindAsync(id);

            battery.Status = status;
            await _context.SaveChangesAsync();         

            return battery;
        }
    }
} 