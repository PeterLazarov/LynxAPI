// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using Models;
// using Data;
// using Microsoft.AspNetCore.Cors;

// namespace Controllers
// {
//     [ApiController]
//     [EnableCors]
//     [Produces("application/json")]
//     [Route("api/regioncasedata")]
//     public class CountryController : ControllerBase
//     {
//         private readonly DataContext _context;

//         public CountryController(DataContext context)
//         {
//             _context = context;
//         }

//         [HttpGet("/api/country")]
//         public async Task<ActionResult<List<Country>>> Get()
//         {
//             return await _context.Countries.ToListAsync();
//         }

//         [HttpGet("/api/country/{id}")]
//         public async Task<ActionResult<Country>> GetById(int id)
//         {
//             return await _context.Countries.FirstOrDefaultAsync(c => c.id == id);;
//         }

//         [HttpPost("/api/country")]
//         public async Task<ActionResult<Country>> Add(Country country)
//         {   
//             await _context.Countries.AddAsync(country);
//             await _context.SaveChangesAsync();
//             //todo: improve result sent
//             return country;
//         }

//         [HttpPut("/api/country/{id}")]
//         public async Task<ActionResult<Country>> Update(string id, Country updatedCountry)
//         {
//             Country country = await _context.Countries.FirstOrDefaultAsync(c => c.id == updatedCountry.id);

//             _context.Countries.Update(country);
//             await _context.SaveChangesAsync();

//             return country;
//         }

//         [HttpDelete("/api/country/{id}")]
//         public async Task<ActionResult<int>> Delete(int id)
//         {
//             Country country = _context.Countries.First(c => c.id == id);

//             _context.Countries.Remove(country);
//             await _context.SaveChangesAsync();

//             return id;
//         } 
//     }
// }
