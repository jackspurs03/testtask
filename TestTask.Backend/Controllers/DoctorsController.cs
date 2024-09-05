using Microsoft.AspNetCore.Mvc;
using TestTask.Backend.Args;
using TestTask.Backend.DTO;
using TestTask.Backend.Services;

namespace TestTask.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsService _service;

        public DoctorsController(IDoctorsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] DoctorArgs args)
        {
            return Ok(_service.ReadPage(args));
        }

        [HttpGet("{doctorId:int}")]
        public IActionResult Get([FromRoute] int doctorId)
        {
            var doctor = _service.ReadByID(doctorId);

            if (doctor == null)
            {
                return NotFound($"Доктор с номером {doctorId} не найден.");
            }

            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult Add([FromBody] DoctorDTO doctor)
        {
            if (doctor == null) return BadRequest();

            return Ok(_service.Create(doctor));
        }

        [HttpPut("{doctorId:int}")]
        public IActionResult Update([FromRoute] int doctorId, [FromBody] DoctorDTO doctor)
        {
            if (doctor == null) return BadRequest();

            var result = _service.Update(doctorId, doctor);

            if (result == null)
            {
                return NotFound($"Доктор с номером {doctorId} не найден.");
            }

            return Ok(result);
        }

        [HttpDelete("{doctorId:int}")]
        public IActionResult Delete([FromRoute] int doctorId)
        {
            var isDeleted = _service.Delete(doctorId);

            if (isDeleted) return Ok();

            return BadRequest("Произошла ошибка при удалении.");
        }
    }
}
