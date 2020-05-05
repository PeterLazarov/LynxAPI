using System;

namespace Models
{
    public class RegionCaseDataModel: BaseModel
    {
        public string SNo {get; set;}
        public string Region {get; set;}
        public string Province {get; set;}   
        public string Deaths {get; set;}
        public string Recovered {get; set;}
        public string ObservationDate {get; set;}   
        public string LastUpdate {get; set;}  
    }
}