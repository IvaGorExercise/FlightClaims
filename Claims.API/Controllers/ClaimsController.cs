using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Claims.API.Data;
using Claims.API.Models;

namespace Claims.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly ClaimContext _context;
        private readonly IDataRepository<Claim> _dataRepository;


        public ClaimsController(ClaimContext context, IDataRepository<Claim> dataRepository)
        {
            _context = context;
            _dataRepository = dataRepository;
        }

        // GET: api/Claim
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Claim>>> GetClaims()
        {
            return await _context.Claim.ToListAsync();
        }

        // GET: api/Claim/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Claim>> GetClaim(int id)
        {
            var claim = await _context.Claim.FindAsync(id); 

            if (claim == null)
            {
                return NotFound();
            }

            return claim;
        }

        // PUT: api/Claim/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaim(int id, Claim claim)
        {
            if (id != claim.Id)
            {
                return BadRequest();
            }

            _context.Entry(claim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaimExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Claim
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        /// <summary>
        /// Creates a Claim item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///       "id": 1,
        ///         "firstName": "Pero",
        ///         "claimCaseNumber": "16029073189",
        ///         "lastName": "Peric",
        ///         "email": "pperic@mail.com",
        ///         "policyNumber": "1111111",
        ///         "originalFlightNumber": "OA123",
        ///         "originalFlightDate": "2020-02-13T14:38:31.8879136",
        ///         "interruptionReason": "WEATHER",
        ///         "interruptionConsequence": "C",
        ///         "newFlightNumber": "OB123",
        ///         "newFlightDate": "2020-02-14T14:38:31.8969904", 
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created Claim item</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        /// <response code="404">Not Found</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpPost]
        public async Task<ActionResult<Claim>> PostClaim([FromBody] Claim claim)
        {
            _context.Claim.Add(claim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClaim", new { id = claim.Id }, claim);
        }


        // DELETE: api/Claim/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Claim>> DeleteClaim(int id)
        {
            var claim = await _context.Claim.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }

            _context.Claim.Remove(claim);
            await _context.SaveChangesAsync();

            return claim;
        }

        private bool ClaimExists(int id)
        {
            return _context.Claim.Any(e => e.Id == id);
        }
    }
}
