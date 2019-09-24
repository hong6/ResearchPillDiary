//using ResearchPillDiary.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResearchPillDiary.Entities
{
  public interface IPillsDiaryRepository
  {
    
    void Add<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    Task<bool> SaveChangesAsync();

    
    Task<Medication[]> GetAllMedicationsAsync();
    Task<Medication> GetMedicationAsync(string medicationId);
    
    Task<Patient[]> GetAllPatientsAsync();
    Task<Patient> GetPatientAsync(string patientId);
   
    Task<PatientMedicationSchedule[]> GetAllPMSAsync();
    Task<PatientMedicationSchedule> GetPMSAsync(string id);    

  }
}