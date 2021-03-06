using System;
using System.Collections.Generic;
using Data;
using Models;

namespace Services 
{
    public class RegionImporter: IRegionImporter
    {     
        private readonly DataContext _context;

        public RegionImporter(DataContext context)
        {
            _context = context;
        }
        
        public void Import(List<RegionCaseDataModel> regionImportData)
        {
            foreach (RegionCaseDataModel regionData in regionImportData) {
                _context.RegionData.Add(regionData);
            }
            _context.SaveChanges();
        }
    }
}