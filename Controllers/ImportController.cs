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
using System;
using Newtonsoft.Json;

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
        [Route("provincedata")]
        public ActionResult ImportProvinceData(object importData)
        {
            var hackParser = JsonConvert.DeserializeObject<Dictionary<string, List<ProvinceCaseDataImportModel>>>(importData.ToString());

            _provinceImporter.Import(hackParser["importData"]);
            
            return StatusCode(200);
        }

        [HttpPost]
        [Route("regiondata")]
        public ActionResult<HttpResponseMessage> ImportRegionData(object importData)
        {
            var hackParser = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<RegionCaseDataModel>>>(importData.ToString());

            _regionImporter.Import(hackParser["importData"]);

            return StatusCode(200);
        }

        [HttpPost]
        [Route("patientdata")]
        public ActionResult ImportPatientData(object importData)
        {
            var hackParser = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<PatientModel>>>(importData.ToString());
            _patientImporter.Import(hackParser["importData"]);
           

            return StatusCode(200);
        }

        [HttpPost]
        [Route("caseupdatedata")]
        public ActionResult ImportCaseUpdateData(object importData)
        {
            var hackParser = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<CaseUpdateModel>>>(importData.ToString());

            _caseUpdateImporter.Import(hackParser["importData"]);

            return StatusCode(200);
        }
    }
}
