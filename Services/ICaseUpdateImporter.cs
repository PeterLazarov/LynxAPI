using System;
using System.Collections.Generic;
using Models;

namespace Services 
{
    public interface ICaseUpdateImporter
    {        
        void Import(List<CaseUpdate> caseUpdateImport);
    }
}