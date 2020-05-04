using System;

namespace Models
{
    public class ProvinceCaseDataModel: BaseModel
    {
        public string Province {get; set;}
        public string Region {get; set;}
        public decimal Lat {get; set;}
        public decimal Long {get; set;}
    }
}