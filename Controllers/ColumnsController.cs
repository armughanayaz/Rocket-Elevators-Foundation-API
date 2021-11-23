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
    public class ColumnsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ColumnsController(ApplicationContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public List<Column>  GetColumns()
        {
            return _context.columns.ToList();
        }
    }  
}
