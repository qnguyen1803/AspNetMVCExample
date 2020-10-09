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
        /// <param name="consultant"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody]Consultant consultant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Entry(consultant).State = EntityState.Modified;
            db.Entry(consultant.User).State = EntityState.Modified;
            try {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                int countConsultant = db.Consultants.Count(c => c.Id == consultant.Id);
                int countUser = db.Users.Count(u => u.Id == consultant.User.Id);
                if (countConsultant == 0)
                    return Content(HttpStatusCode.NotFound, "Consultant not found");
                if (countUser == 0)
                    return Content(HttpStatusCode.NotFound, "User not found");
                throw;
            }
            return Ok();
        }

        /// <summary>
        /// Remove Consultant By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            Consultant consultant = await db.Consultants.FindAsync(id);
            if (consultant == null)
                return Content(HttpStatusCode.NotFound, "Consultant not found");
            User user = await db.Users.FindAsync(consultant.UserId);
            if (user == null)
                return Content(HttpStatusCode.NotFound, "User not found");
            db.Consultants.Remove(consultant);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
