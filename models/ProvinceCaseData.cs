using System;

namespace Models
{
    public class ProvinceCaseData: BaseModel
    {
        public string Province {get; set;}
        public string Region {get; set;}
        public string Lat {get; set;}
        public string Long {get; set;}
        public string Status {get; set;}
    }
}