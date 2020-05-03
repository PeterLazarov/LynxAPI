using System;
using System.Collections.Generic;
using Models;

namespace Services 
{
    public interface IRegionImporter
    {        
        void Import(List<RegionCaseData> regionImportData);
    }
}