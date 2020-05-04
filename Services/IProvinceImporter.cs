using System;
using System.Collections.Generic;
using Models;

namespace Services 
{
    public interface IProvinceImporter
    {        
        void Import(List<ProvinceCaseDataImportModel> provinceImportData);
    }
}