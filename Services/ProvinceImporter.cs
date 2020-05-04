using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public void Import(List<ProvinceCaseDataImportModel> provinceImportData)
        {
            foreach (ProvinceCaseDataImportModel provinceData in provinceImportData) {

                ProvinceCaseDataModel province = _context.ProvinceData.Where(x => 
                    x.Region == provinceData.Region && x.Province == provinceData.Province).FirstOrDefault();

                if (province == null) {
                    province= new ProvinceCaseDataModel{
                        Province = provinceData.Province,
                        Region = provinceData.Region,
                        Lat = provinceData.Lat,
                        Long = provinceData.Long,
                    }; 
                    _context.ProvinceData.Add(province);
                    _context.SaveChanges();
                }

                if (provinceData.DailyData != null) {
                    foreach (var dayData in provinceData.DailyData)
                    {
                        dayData.ProvinceId = province.Id.Value;
            
                        _context.ProvinceDayData.Add(dayData);
                    }
                    _context.SaveChanges();
                }
            }
        }
    }
}