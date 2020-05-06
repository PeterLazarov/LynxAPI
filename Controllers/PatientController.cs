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
    [Route("api/patient")]
    public class PatientController : ControllerBase
    {
        private readonly DataContext _context;

        public PatientController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<PatientModel>> Get([FromQuery] PatientFilter filter)
        {
            return _context.Patients.Where(x=> 
                (String.IsNullOrEmpty(filter.Country) || x.NewCountry.ToUpper().Contains(filter.Country.ToUpper()))
            )
            .ToList();
        }
    }
}
