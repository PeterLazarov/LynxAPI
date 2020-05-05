using System;

namespace Models
{
    public class CaseUpdateModel: BaseModel
    {
        public string Country {get; set;}
        public string Location {get; set;}
        public string CaseInCountry {get; set;}
        public string ReportingDate {get; set;}
        public string HospitalVisitDate {get; set;}
        public string SymptomOnset {get; set;}
        public string ExposureStart {get; set;}
        public string ExposureEnd {get; set;}
        public string Age {get; set;}
        public string Gender {get; set;}
        public bool? IsOnsetApproximated {get; set;}
        public bool VisitedWuhan {get; set;}
        public bool FromWuhan {get; set;}
        public bool IsDead {get; set;}
        public bool IsRecovered {get; set;}
        public string Symptoms {get; set;}
        public string Summary {get; set;}
        public string Source {get; set;}
        public string Link {get; set;}
    }
}