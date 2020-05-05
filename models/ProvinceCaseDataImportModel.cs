using System;
using System.Collections.Generic;

namespace Models
{
    public class ProvinceCaseDataImportModel
    {
        public string Province {get; set;}
        public string Region {get; set;}
        public string Lat {get; set;}
        public string Long {get; set;}
        public string Status {get; set;}

        public List<ProvinceCaseDayDataModel> DailyData {get; set;}
    }
}