using AltranSIWallet.Models;
using AltranSIWallet.ModelsDto.Consultant;
using AltranSIWallet.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AltranSIWallet.Controllers
{
    public class ConsultantsController : ApiController
    {
        private AltranSIWalletContext db = new AltranSIWalletContext();

        /// <summary>
        /// Get All Consultants
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IQueryable<Consultant> GetAll()
        {
            return db.Consultants;
        }

        /// <summary>
        /// Get List Consultants By Level 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public IQueryable<Consultant> GetListByLevels(ELevels level)
        {
            var consultants = db.Consultants.Where(item => item.Level == level);
            return consultants;
        }

        /// <summary>
        /// Get Consultant By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
                return Content(HttpStatusCode.NotFound, "Consultant not found");
            return Ok(consultant);
        }

        /// <summary>
        /// Create new Consultant
        /// </summary>
        /// <param name="consultant"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]Consultant consultant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (consultant.User == null)
                return BadRequest("User can not be null");
            db.Users.Add(consultant.User);
            db.Consultants.Add(consultant);
            await db.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Update a consultant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="consultant"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Update([FromUri] int id,[FromBody]Consultant consultant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (consultant.Id != id)
                return BadRequest();

            db.Entry(consultant).State = EntityState.Modified;
            try {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                int count = db.Consultants.Count(c => c.Id == id);
                if (count == 0)
                    return Content(HttpStatusCode.NotFound, "Consultant not found");
                else
                    throw;
            }
            return Ok();
        }

        /// <summary>
        /// Remove Consultant By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Delete(int id)
        {
            Consultant consultant = await db.Consultants.FindAsync(id);
            User user = await db.Users.FindAsync(consultant.UserId);
            if (consultant == null || user == null)
                return Content(HttpStatusCode.NotFound, "Consultant or User not found");
            db.Consultants.Remove(consultant);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
