using CompShop.Common;
using CompShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompShop.API.Controllers
{
    public class LaptopController : ApiControllerBase
    {
        private readonly ILogger<LaptopController> _logger;
        private readonly AppDbContext _context;

        public LaptopController(ILogger<LaptopController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Laptop>>> GetLaptops()
        {
            return await _context.Laptops
                                 .Include(x => x.Brand)
                                 .Include(x => x.Specifications)
                                 .ToListAsync();
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddLaptop([FromBody] Laptop laptop)
        {
            //Check for null and make sure all required parameters are supplied
            if (laptop != null && ModelState.IsValid)
            {
                try
                {
                    //Add the laptop object to the database context
                    await _context.Laptops.AddAsync(laptop);
                    var result = await _context.SaveChangesAsync();

                    //Check if the laptop is added
                    if (result > 0)
                        return CreatedAtAction(nameof(AddLaptop), laptop.Id);
                    else
                        return Problem("Unable to add laptop at this time");
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }
            else
                return BadRequest(ModelState);
        }
    }
}
