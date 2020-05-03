using System;
using System.Collections.Generic;
using Data;
using Models;

namespace Services 
{
    public class CaseUpdateImporter: ICaseUpdateImporter
    {     
        private readonly DataContext _context;

        public CaseUpdateImporter(DataContext context)
        {
            _context = context;
        }
        
        public void Import(List<CaseUpdate> caseUpdateImport)
        {
            foreach (CaseUpdate caseUpdate in caseUpdateImport) {
                _context.CaseUpdates.Add(caseUpdate);
            }
            _context.SaveChanges();
        }
    }
}