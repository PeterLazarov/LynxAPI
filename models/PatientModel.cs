using System;

namespace Models
{
    public class PatientModel: BaseModel
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
        public string HospitalAdmissionDate {get; set;}
        public string ConfirmationDate {get; set;}
        public string DateDeadOrDischarge {get; set;}
        public string DateOnsetSymptoms {get; set;}
        public string GeoResolution {get; set;} 
        public decimal Longtitude {get; set;}
        public decimal Lattitude {get; set;}
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