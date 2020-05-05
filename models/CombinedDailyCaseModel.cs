using System;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class CombinedDailyCaseModel
    {
        public int ProvinceId {get; set;}
        public string Day {get; set;}
        public string ConfirmedCases {get; set;}
        public string DeadCases {get; set;}
        public string RecoveredCases {get; set;}
    }
}