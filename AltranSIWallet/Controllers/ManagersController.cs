using AltranSIWallet.Models;
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
    public class ManagersController : ApiController
    {
        AltranSIWalletContext db = new AltranSIWalletContext();

        /// <summary>
        /// Get All Managers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IQueryable<Manager> GetAll()
        {
            return db.Managers;
        }

        /// <summary>
        /// Get Manager By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Manager manager = await db.Managers.FindAsync(id);
            if (manager == null)
                return Content(HttpStatusCode.NotFound, "Manager not found");
            return Ok(manager);
        }

        /// <summary>
        /// Create new Manager
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Create(Manager manager)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (manager.User == null)
                return BadRequest("User can not be null");
            db.Users.Add(manager.User);
            db.Managers.Add(manager);
            await db.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Update Data of Manager
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody]Manager manager)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Entry(manager).State = EntityState.Modified;
            db.Entry(manager.User).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                int countManager = db.Managers.Count(m => m.Id == manager.Id);
                int countUser = db.Users.Count(u => u.Id == manager.UserId);
                if (countManager == 0)
                    return Content(HttpStatusCode.NotFound, "Manager not found");
                if (countUser == 0)
                    return Content(HttpStatusCode.NotFound, "User not found");

                throw;
            }
  
            return Ok();
        }

        /// <summary>
        /// Remove Manager By Id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            Manager manager = await db.Managers.FindAsync(id);
            if (manager == null)
                return Content(HttpStatusCode.NotFound, "Manager not found");
            User user = await db.Users.FindAsync(manager.UserId);
            if (user == null)
                return Content(HttpStatusCode.NotFound, "User not found");
            db.Managers.Remove(manager);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok();
        }


    }
}
