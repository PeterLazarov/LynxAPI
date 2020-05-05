using System;

namespace Models
{
    public class ProvinceCaseDayDataModel: BaseModel
    {
        public string Day {get; set;}
        public string Cases {get; set;}
        public string Status {get; set;}
        public int ProvinceId {get; set;}
    }
}