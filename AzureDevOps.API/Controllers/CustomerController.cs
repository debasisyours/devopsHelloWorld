using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureDevOps.Domain.Entities;
using AzureDevOps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureDevOps.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ISaveCustomerService _saveCustomerService = null;

        public CustomerController(ISaveCustomerService saveCustomerService)
        {
            _saveCustomerService = saveCustomerService;
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveCustomerAsync([FromBody] Customer customer)
        {
            return Ok(await _saveCustomerService.SaveCustomerAsync(customer));
        }
    }
}
