using Kitabist.Cargo.BusinessLayer.Abstract;
using Kitabist.Cargo.DtoLayer.DTOs.CargoOperationDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kitabist.Cargo.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _CargoOperationService;
        public CargoOperationsController(ICargoOperationService CargoOperationService)
        {
            _CargoOperationService = CargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _CargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            Kitabist.Cargo.EntityLayer.Concrete.CargoOperation CargoOperation = new Kitabist.Cargo.EntityLayer.Concrete.CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate
            };
            _CargoOperationService.TInsert(CargoOperation);
            return Ok("Cargo operation has been created");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _CargoOperationService.TDelete(id);
            return Ok("Cargo operation has been deleted");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var values = _CargoOperationService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            Kitabist.Cargo.EntityLayer.Concrete.CargoOperation CargoOperation = new Kitabist.Cargo.EntityLayer.Concrete.CargoOperation()
            {
                Barcode = updateCargoOperationDto.Barcode,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate
            };
            _CargoOperationService.TUpdate(CargoOperation);
            return Ok("Cargo operation has been updated");
        }
    }
}
