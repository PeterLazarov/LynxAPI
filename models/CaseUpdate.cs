using System;

namespace Models
{
    public class CaseUpdate: BaseModel
    {
        public string Link {get; set;}
        public string Country {get; set;}
        public int? CaseInCountry {get; set;}
        public DateTime ReportingDate {get; set;}
        public DateTime HospitalVisitDate {get; set;}
        public DateTime SymptomOnset {get; set;}
        public DateTime? ExposureStart {get; set;}
        public DateTime? ExposureEnd {get; set;}
        public bool? IsOnsetApproximated {get; set;}
        public bool VisitedWuhan {get; set;}
        public bool FromWuhan {get; set;}
        public bool Dead {get; set;}
        public bool Recovered {get; set;}
        public string Summary {get; set;}
        public string Location {get; set;}
        public string Gender {get; set;}
        public int Age {get; set;}
        public string Symptoms {get; set;}
        public string Source {get; set;}
    }
}