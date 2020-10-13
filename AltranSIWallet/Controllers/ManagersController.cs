using AltranSIWallet.Models;
using AltranSIWallet.Repositories;
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
        private AltranSIWalletContext db;
        private ManagerRepository managerRepository;
        private UserRepository userRepository;

        public ManagersController()
        {
            db = new AltranSIWalletContext();
            managerRepository = new ManagerRepository(db);
            userRepository = new UserRepository(db);
    }
        /// <summary>
        /// Get All Managers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Manager> managers = await managerRepository.FindAll().ToListAsync();
            return Ok(managers);
        }

        /// <summary>
        /// Get Manager By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Manager manager = await managerRepository.FindByCondition(item => item.Id == id).FirstOrDefaultAsync();
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
           userRepository.Create(manager.User);
           managerRepository.Create(manager);
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

            managerRepository.Update(manager);
            userRepository.Update(manager.User);

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                Manager managerToUpdate = await managerRepository.FindByCondition(item => item.Id == manager.Id).FirstOrDefaultAsync();
                if (managerToUpdate == null)
                    return Content(HttpStatusCode.NotFound, "Manager not found");
                User userToUpdate = await userRepository.FindByCondition(item => item.Id == manager.User.Id).FirstOrDefaultAsync();
                if (userToUpdate == null)
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
            Manager manager = await managerRepository.FindByCondition(item => item.Id == id).FirstOrDefaultAsync();
            if (manager == null)
                return Content(HttpStatusCode.NotFound, "Manager not found");
            User user = await userRepository.FindByCondition(item => item.Id == manager.UserId).FirstOrDefaultAsync();
            if (user == null)
                return Content(HttpStatusCode.NotFound, "User not found");
            userRepository.Delete(user);
            managerRepository.Delete(manager);
            await db.SaveChangesAsync();
            return Ok();
        }


    }
}
