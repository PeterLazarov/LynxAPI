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
    [Route("api/caseupdate")]
    public class CaseUpdateController : ControllerBase
    {
        private readonly DataContext _context;

        public CaseUpdateController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<CaseUpdateModel>> Get([FromQuery] CaseUpdateFilter filter)
        {
            return _context.CaseUpdates.Where(x=> 
                (String.IsNullOrEmpty(filter.Country) || x.Country.ToUpper().Contains(filter.Country.ToUpper()))
                && (String.IsNullOrEmpty(filter.Location) || x.Location.ToUpper().Contains(filter.Location.ToUpper()))
            ).OrderBy(x => x.Country).ThenBy(x => x.CaseInCountry)
            .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CaseUpdateModel> GetById(int id)
        {
            return _context.CaseUpdates.FirstOrDefault(c => c.Id == id);
        }
    }
}
