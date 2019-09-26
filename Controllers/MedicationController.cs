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
    public class MedicationController : ControllerBase
    {
        private readonly IPillsDiaryRepository _repository;

        public MedicationController(IPillsDiaryRepository repository)
        {
            _repository = repository;

        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllMedicationsAsync();

                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{medicationId}")]
        public async Task<ActionResult<Medication>> Get(string medicationId)
        {
            try
            {
                var result = await _repository.GetMedicationAsync(medicationId);

                if (result == null)
                    return NotFound();

                return Ok(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }        

        public async Task<ActionResult<Medication>> Post(Medication medication)
        {
            try
            {
                var existing = await _repository.GetMedicationAsync(medication.MedicationId);
                if (existing != null)
                {
                    return BadRequest("Medication is alreay existing");
                }
               
                _repository.Add(medication);

                if (await _repository.SaveChangesAsync())
                {                    
                    return Created($"/api/camps/{medication.MedicationId}", medication);
                }

            }
            catch (Exception e)
            {
                var msg = e.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

    
    }
}
