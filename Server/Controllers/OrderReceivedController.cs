using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderReceivedController(IGenericRepositoryInterface<OrderReceived> genericRepositoryInterface)
        : GenericController<OrderReceived>(genericRepositoryInterface)
    {
    }

    //public class OrderReceivedController : GenericController<OrderReceived>
    //{
    //    private readonly IGenericRepositoryInterface<OrderDelivery> _orderDeliveryRepository;

    //    // Inject both OrderReceived and OrderDelivery repositories
    //    public OrderReceivedController(
    //        IGenericRepositoryInterface<OrderReceived> genericRepositoryInterface,
    //        IGenericRepositoryInterface<OrderDelivery> orderDeliveryRepository
    //    ) : base(genericRepositoryInterface)
    //    {
    //        _orderDeliveryRepository = orderDeliveryRepository;
    //    }

    //    // Custom method to transfer data from OrderDelivery to OrderReceived
    //    [HttpPost("transfer")]
    //    public async Task<IActionResult> TransferDataToOrderReceived([FromBody] OrderReceivedDto dto)
    //    {
    //        // Fetch the OrderDelivery based on OrderDeliveryId from the DTO
    //        var orderDelivery = await _orderDeliveryRepository.GetByIdAsync(dto.OrderDeliveryId);

    //        if (orderDelivery == null)
    //        {
    //            return NotFound("OrderDelivery not found.");
    //        }

    //        // Check if the OrderDelivery is complete (i.e., required fields are filled)
    //        if (orderDelivery.Schedule == default || orderDelivery.Conforme == default || orderDelivery.Deadline == default)
    //        {
    //            return BadRequest("OrderDelivery data is incomplete.");
    //        }

    //        // Create a new OrderReceived entity using data from the DTO and OrderDelivery
    //        var orderReceived = new OrderReceived
    //        {
    //            OrderDeliveryId = orderDelivery.Id,
    //            DateReceived = dto.DateReceived,
    //            DeliveryDays = (dto.DateReceived - orderDelivery.Schedule).Days, // Calculate delivery days
    //            ExtensionLetterFileName = dto.ExtensionLetterFileName,
    //            ExtensionLetterContent = dto.ExtensionLetterContent
    //        };

    //        // Insert the new OrderReceived record into the database
    //        await _genericRepositoryInterface.Insert(orderReceived);
    //        await _genericRepositoryInterface.SaveAsync();

    //        return CreatedAtAction(nameof(TransferDataToOrderReceived), new { id = orderReceived.Id }, orderReceived);
    //    }
    //}
}
