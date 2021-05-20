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
    public class SpecificationController : ApiControllerBase
    {
        private readonly ILogger<SpecificationController> _logger;
        private readonly AppDbContext _context;

        public SpecificationController(ILogger<SpecificationController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Specification>>> GetSpecs()
        {
            return await _context.Specifications
                                 .Include(x => x.Config)
                                 .ToListAsync();
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddSpec([FromBody] Specification spec)
        {
            //Check for null and make sure all required parameters are supplied
            if (spec != null && ModelState.IsValid)
            {
                try
                {
                    //Add the specification object to the database context
                    await _context.Specifications.AddAsync(spec);
                    var result = await _context.SaveChangesAsync();

                    //Check if the specification is added 
                    if (result > 0)
                        return CreatedAtAction(nameof(AddSpec), spec.Id);
                    else
                        return Problem("Unable to add specification at this time");
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException != null)
                        return BadRequest(ex.InnerException.Message);
                    
                    return BadRequest("Unable to update the database " + ex.Message);
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
