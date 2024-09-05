using Microsoft.AspNetCore.Mvc;
using TestTask.Backend.Args;
using TestTask.Backend.DTO;
using TestTask.Backend.Services;

namespace TestTask.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsService _service;

        public PatientsController(IPatientsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] PatientArgs args)
        {
            return Ok(_service.ReadPage(args));
        }

        [HttpGet("{patientId:int}")]
        public IActionResult Get([FromRoute] int patientId)
        {
            var patient = _service.ReadByID(patientId);

            if (patient == null)
            {
                return NotFound($"Доктор с номером {patientId} не найден.");
            }

            return Ok(patient);
        }

        [HttpPost]
        public IActionResult Add([FromBody] PatientDTO patient)
        {
            if (patient == null) return BadRequest();

            return Ok(_service.Create(patient));
        }

        [HttpPut("{patientId:int}")]
        public IActionResult Update([FromRoute] int patientId, [FromBody] PatientDTO patient)
        {
            if (patient == null) return BadRequest();

            var result = _service.Update(patientId, patient);

            if (result == null)
            {
                return NotFound($"Доктор с номером {patientId} не найден.");
            }

            return Ok(result);
        }

        [HttpDelete("{patientId:int}")]
        public IActionResult Delete([FromRoute] int patientId)
        {
            var isDeleted = _service.Delete(patientId);

            if (isDeleted) return Ok();

            return BadRequest("Произошла ошибка при удалении.");
        }
    }
}
