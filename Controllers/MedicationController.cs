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

    }
}