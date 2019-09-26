using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResearchPillDiary.Entities;

namespace ResearchPillDiary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PMSController : ControllerBase
    {
        private readonly IPillsDiaryRepository _repository;

        public PMSController(IPillsDiaryRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllPMSAsync();

                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientMedicationSchedule>> Get(string id)
        {
            try
            {
                var result = await _repository.GetPMSAsync(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        
        public async Task<ActionResult<PatientMedicationSchedule>> Post(PatientMedicationSchedule patientMedicationSchedule)
        {
            try
            {
                var existing = await _repository.GetPMSAsync(patientMedicationSchedule.PatientMedicationScheduleId);
                if (existing != null)
                {
                    return BadRequest("PatientMedicationSchedule is alreay existing");
                }

                _repository.Add(patientMedicationSchedule);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/patientMedicationSchedule/{patientMedicationSchedule.PatientMedicationScheduleId}", patientMedicationSchedule);
                }

            }
            catch (Exception e)
            {
                var msg = e.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, "patientMedicationSchedule Database Failure");
            }

            return BadRequest();
        }

    }
}
