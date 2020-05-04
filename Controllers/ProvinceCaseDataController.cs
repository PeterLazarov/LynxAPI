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
    [Route("api/provincecasedata")]
    public class ProvinceCaseDataController : ControllerBase
    {
        private readonly DataContext _context;

        public ProvinceCaseDataController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<ProvinceCaseDataModel>> Get([FromQuery] RegionCaseDataFilter filter)
        {
            return _context.ProvinceData.Where(x=> 
                (String.IsNullOrEmpty(filter.Province) || x.Province.ToUpper().Contains(filter.Province.ToUpper()))
                && (String.IsNullOrEmpty(filter.Region) || x.Region.ToUpper().Contains(filter.Region.ToUpper())) 
            ).OrderBy(x => x.Province)
            .ToList();
        }

        [HttpGet("/{id}")]
        public ActionResult<ProvinceCaseDataModel> GetById(int id)
        {
            return _context.ProvinceData.FirstOrDefault(c => c.Id == id);
        }
    }
}
