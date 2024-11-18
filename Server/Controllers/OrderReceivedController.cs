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
}
