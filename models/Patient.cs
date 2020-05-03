using System;

namespace Models
{
    public class Patient: BaseModel
    {
        public string AdditionalInformation {get; set;}
        public string Admin1 {get; set;}
        public string Admin2 {get; set;}
        public string Admin3 {get; set;}
        public string AdminId {get; set;} 
        public string ChronicDiseases {get; set;}
        public string ChronicDiseaseBinary {get; set;} 
        public int Age {get; set;}
        public string City {get; set;}
        public string Country {get; set;}
        public string NewCountry {get; set;} 
        public string DataModeratorInitials {get; set;} 
        public DateTime HospitalAdmissionDate {get; set;}
        public DateTime ConfirmationDate {get; set;}
        public DateTime? DateDeadOrDischarge {get; set;}
        public DateTime? DateOnsetSymptoms {get; set;}
        public string GeoResolution {get; set;} 
        public string Longtitude {get; set;}
        public string Lattitude {get; set;}
        public bool LivesInWuhan {get; set;}
        public string Location {get; set;}
        public string NotesForDiscussion {get; set;}
        public string Outcome {get; set;}
        public string Province {get; set;}
        public string ReportedMarketExposure {get; set;}
        public string SequenceAvailable {get; set;} 
        public string Sex {get; set;}
        public string TravelHistoryDates {get; set;}
        public string TravelHistoryLocation {get; set;}
    }
}