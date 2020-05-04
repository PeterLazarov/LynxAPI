using System;
using System.Collections.Generic;
using Data;
using Models;

namespace Services 
{
    public class PatientImporter: IPatientImporter
    {     
        private readonly DataContext _context;

        public PatientImporter(DataContext context)
        {
            _context = context;
        }
        
        public void Import(List<PatientModel> patientImport)
        {
            foreach (PatientModel patientData in patientImport) {
                _context.Patients.Add(patientData);
            }
            _context.SaveChanges();
        }
    }
}