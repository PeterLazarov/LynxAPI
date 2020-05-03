using System;
using System.Collections.Generic;
using Data;
using Models;

namespace Services 
{
    public class ProvinceImporter: IProvinceImporter
    {     
        private readonly DataContext _context;

        public ProvinceImporter(DataContext context)
        {
            _context = context;
        }
        
        public void Import(List<ProvinceCaseData> provinceImportData)
        {
            foreach (ProvinceCaseData provinceData in provinceImportData) {
                _context.ProvinceData.Add(provinceData);
            }
            _context.SaveChanges();
        }
    }
}