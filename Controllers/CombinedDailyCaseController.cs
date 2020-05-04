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
    [Route("api/CombinedDailyCase")]
    public class CombinedDailyCaseController : ControllerBase
    {
        private readonly DataContext _context;

        public CombinedDailyCaseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<CombinedDailyCaseModel>> Get([FromQuery] CombinedDailyCaseFilter filter)
        {
            return _context.CombinedDailyCases.Where(x=> 
                filter.ProvinceId.HasValue && x.ProvinceId == filter.ProvinceId.Value
            ).OrderByDescending(x => x.Day)
            .ToList();
        }
    }
}
