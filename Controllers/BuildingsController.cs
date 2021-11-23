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
    public class BuildingsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BuildingsController(ApplicationContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public List<Elevator> GetBuildings()
        {
            var buildings = _context.batteries.ToList();
            var batteries = _context.batteries.ToList();
            var columns = _context.columns.ToList();
            var elevators = _context.elevators.ToList();

            var filteredBatteries = batteries.Where(battety => battety.Status == "intervention").ToList();
            var filteredColumns = columns.Where(column => column.Status == "intervention").ToList();
            var filteredElevators = elevators.Where(elevator => elevator.Status == "intervention").ToList();

            foreach (Battery battery in filteredBatteries) 
            {
                List<KeyValuePair<Battery, List<KeyValuePair<Column, List<Elevator>>>>> result = new List<KeyValuePair<Battery, List<KeyValuePair<Column, List<Elevator>>>>>();
                
                
                var currentColumns = new List<Column>();
                foreach (Column column in filteredColumns) 
                {
                    if (column.BatteryId == battery.Id) 
                    {
                        currentColumns.Add(column);
                        var currentElevator = new List<Elevator>();
                        foreach(Elevator elevator in filteredElevators) 
                        {
                            if ( elevator.ColumnId == column.Id) 
                            {
                               currentElevator.Add(elevator);
                            }
                        }
                    }
                }
            }



            return filteredElevators;

        }
    }  
}
