using System;
using System.Collections.Generic;
using Models;

namespace Services 
{
    public interface IPatientImporter
    {        
        void Import(List<PatientModel> patientImport);
    }
}