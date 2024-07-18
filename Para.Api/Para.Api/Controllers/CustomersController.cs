using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Para.Data.Domain;
using Para.Data.UnitOfWork;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customers = await unitOfWork.Include<Customer>(
                    x => x.CustomerAddresses,
                    x => x.CustomerPhones,
                    x => x.CustomerDetail
                );

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(long customerId)
        {
            try
            {
                var customer = await unitOfWork.Include<Customer>(
                    x => x.CustomerAddresses,
                    x => x.CustomerPhones,
                    x => x.CustomerDetail
                );

                var result = customer.FirstOrDefault(x => x.Id == customerId);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer value)
        {
            try
            {
                await unitOfWork.CustomerRepository.Insert(value);
                await unitOfWork.Complete();
                return CreatedAtAction(nameof(Get), new { customerId = value.Id }, value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> Put(long customerId, [FromBody] Customer value)
        {
            try
            {
                var customer = await unitOfWork.CustomerRepository.GetById(customerId);
                if (customer == null)
                {
                    return NotFound();
                }

                unitOfWork.CustomerRepository.Update(value);
                await unitOfWork.Complete();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(long customerId)
        {
            try
            {
                var customer = await unitOfWork.CustomerRepository.GetById(customerId);
                if (customer == null)
                {
                    return NotFound();
                }

                await unitOfWork.CustomerRepository.Delete(customerId);
                await unitOfWork.Complete();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
