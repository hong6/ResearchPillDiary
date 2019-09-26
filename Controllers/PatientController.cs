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
    public class PatientController : ControllerBase
    {
        private readonly IPillsDiaryRepository _repository;

        public PatientController(IPillsDiaryRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllPatientsAsync();

                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{patientId}")]
        public async Task<ActionResult<Patient>> Get(string patientId)
        {
            try
            {
                var result = await _repository.GetPatientAsync(patientId);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
        
        public async Task<ActionResult<Patient>> Post(Patient patient)
        {
            try
            {
                var existing = await _repository.GetPatientAsync(patient.PatientId);
                if (existing != null)
                {
                    return BadRequest("This patient is alreay existing");
                }

                _repository.Add(patient);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/patient/{patient.PatientId}", patient);
                }

            }
            catch (Exception e)
            {
                var msg = e.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Add Patient Database Failure");
            }

            return BadRequest();
        }
    }
}
