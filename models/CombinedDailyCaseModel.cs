using System;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class CombinedDailyCaseModel
    {
        public int ProvinceId {get; set;}
        public string Day {get; set;}
        public int ConfirmedCases {get; set;}
        public int DeadCases {get; set;}
        public int RecoveredCases {get; set;}
    }
}