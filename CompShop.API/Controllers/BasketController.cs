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
    public class BasketController : ApiControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly AppDbContext _context;

        public BasketController(ILogger<BasketController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Basket>>> GetBaskets()
        {
            return await _context.ShoppingBasket
                                 .Include(x => x.Laptop)
                                 .Include(x => x.Specifications)
                                 .ToListAsync();
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddBasket([FromBody] Basket basket)
        {
            //Check for null and make sure all required parameters are supplied
            if (basket != null && ModelState.IsValid)
            {
                try
                {
                    var distinctSpec = basket.Specifications
                        .Select(m => new { m.Name })
                        .Distinct()
                        .ToList();

                    if (distinctSpec.Count < basket.Specifications.Count)
                        return Problem("Duplicate specifications not allowed");

                    //Add the basket object to the database context
                    await _context.ShoppingBasket.AddAsync(basket);
                    var result = await _context.SaveChangesAsync();

                    //Check if the basket is added 
                    if (result > 0)
                        return CreatedAtAction(nameof(AddBasket), basket.Id);
                    else
                        return Problem("Unable to add to basket at this time");
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
