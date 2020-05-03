using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using Microsoft.AspNetCore.Cors;
using System;

namespace Controllers
{
    [ApiController]
    [EnableCors]
    [Produces("application/json")]
    [Route("api/regioncasedata")]
    public class RegionCaseDataController : ControllerBase
    {
        private readonly DataContext _context;

        public RegionCaseDataController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<RegionCaseData>> Get([FromQuery] RegionCaseDataFilter filter)
        {
            return _context.RegionData.Where(x=> 
                (String.IsNullOrEmpty(filter.Province) || x.Province.ToUpper().Contains(filter.Province.ToUpper()))
                && (String.IsNullOrEmpty(filter.Region) || x.Region.ToUpper().Contains(filter.Region.ToUpper())) 
            ).OrderBy(x => x.SNo)
            .ToList();
        }

        [HttpGet("/{id}")]
        public ActionResult<RegionCaseData> GetById(int id)
        {
            return _context.RegionData.FirstOrDefault(c => c.Id == id);
        }
    }
}
