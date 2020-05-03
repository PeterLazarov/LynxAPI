using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using Services;
using Microsoft.AspNetCore.Cors;
using System.Text.Json;
using System.Net.Http;

namespace Controllers
{
    [ApiController]
    [EnableCors]
    [Produces("application/json")]
    [Route("api/import")]
    public class ImportController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IProvinceImporter _provinceImporter;
        private readonly IRegionImporter _regionImporter;
        private readonly IPatientImporter _patientImporter;
        private readonly ICaseUpdateImporter _caseUpdateImporter;

        public ImportController(DataContext context, IProvinceImporter provinceImporter, 
            IRegionImporter regionImporter, IPatientImporter patientImporter, 
            ICaseUpdateImporter caseUpdateImporter)
        {
            _context = context;
            _provinceImporter = provinceImporter;
            _regionImporter = regionImporter;
            _patientImporter = patientImporter;
            _caseUpdateImporter = caseUpdateImporter;
        }

        [HttpPost]
        [Route("provicedata")]
        public ActionResult ImportProvinceData(ProvinceCaseData[] importData)
        {
            var hackParser = JsonSerializer.Deserialize<Dictionary<string, List<ProvinceCaseData>>>(importData.ToString());

            _provinceImporter.Import(hackParser["importData"]);

            return StatusCode(200);
        }

        [HttpPost]
        [Route("regiondata")]
        public ActionResult<HttpResponseMessage> ImportRegionData(object importData)
        {
            var hackParser = JsonSerializer.Deserialize<Dictionary<string, List<RegionCaseData>>>(importData.ToString());

            _regionImporter.Import(hackParser["importData"]);

            return StatusCode(200);
        }

        [HttpPost]
        [Route("patientdata")]
        public ActionResult ImportPatientData(Patient[] importData)
        {
            var hackParser = JsonSerializer.Deserialize<Dictionary<string, List<Patient>>>(importData.ToString());

            _patientImporter.Import(hackParser["importData"]);

            return StatusCode(200);
        }

        [HttpPost]
        [Route("caseupdatedata")]
        public ActionResult ImportCaseUpdateData(CaseUpdate[] importData)
        {
            var hackParser = JsonSerializer.Deserialize<Dictionary<string, List<CaseUpdate>>>(importData.ToString());

            _caseUpdateImporter.Import(hackParser["importData"]);

            return StatusCode(200);
        }
    }
}
