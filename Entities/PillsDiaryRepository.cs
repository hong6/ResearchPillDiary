using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResearchPillDiary.Entities;

namespace ResearchPillDiary.Entities
{
  public class PillsDiaryRepository : IPillsDiaryRepository
    {
    private readonly PillsDiaryContext _context;
    private readonly ILogger<PillsDiaryRepository> _logger;

    public PillsDiaryRepository(PillsDiaryContext context, ILogger<PillsDiaryRepository> logger)
    {
      _context = context;
      _logger = logger;
    }

    public void Add<T>(T entity) where T : class 
    {
      _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
      _context.Add(entity);
    }

    public void Delete<T>(T entity) where T: class
    {
      _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
      _context.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
      _logger.LogInformation($"Attempitng to save the changes in the context");

      // Only return success if at least one row was changed
      return (await _context.SaveChangesAsync()) > 0;
    }
    

    public async Task<Medication[]> GetAllMedicationsAsync()
    {
        _logger.LogInformation($"Getting all Medications");

        IQueryable<Medication> query = _context.Medication;       
        query = query.OrderByDescending(m=>m.MedicationId);

        return await query.ToArrayAsync();
    }

    public async Task<Medication> GetMedicationAsync(string medicationId)
    {
        _logger.LogInformation($"Getting a Medication for {medicationId}");

        IQueryable<Medication> query = _context.Medication;    
        query = query.Where(m => m.MedicationId == medicationId);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<Patient[]> GetAllPatientsAsync()
    {
        _logger.LogInformation($"Getting all Patient");

        IQueryable<Patient> query = _context.Patient;
        query = query.OrderByDescending(p => p.PatientId);

        return await query.ToArrayAsync();
    }

    public async Task<Patient> GetPatientAsync(string patientId)
    {
        _logger.LogInformation($"Getting a Patient");

        IQueryable<Patient> query = _context.Patient;     
        query = query.Where(p=>p.PatientId == patientId);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<PatientMedicationSchedule[]> GetAllPMSAsync()
    {
        _logger.LogInformation($"Getting all PatientMedicationSchedule");

        IQueryable<PatientMedicationSchedule> query = _context.PatientMedicationSchedule;
        query = query.OrderByDescending(p => p.PatientMedicationScheduleId);

        return await query.ToArrayAsync();
    }   


    public async Task<PatientMedicationSchedule> GetPMSAsync(string id)
    {
      _logger.LogInformation($"Getting a PatientMedicationSchedule");

      var query = _context.PatientMedicationSchedule
        .Where(t => t.PatientMedicationScheduleId == id);

      return await query.FirstOrDefaultAsync();
    }     
       
    }
}
