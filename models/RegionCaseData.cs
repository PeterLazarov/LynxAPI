using System;

namespace Models
{
    public class RegionCaseData: BaseModel
    {
        public int? SNo {get; set;}
        public string Region {get; set;}
        public int? Deaths {get; set;}
        public int? Recovered {get; set;}
        public string LastUpdate {get; set;}
        public string ObservationDate {get; set;}
        public string Province {get; set;}        
    }
}