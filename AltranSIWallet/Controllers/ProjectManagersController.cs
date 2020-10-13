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
    public class ProjectManagersController : ApiController
    {
        private AltranSIWalletContext db;
        private ProjectManagerRepository projectManagerRepository;
        private UserRepository userRepository;

        public ProjectManagersController()
        {
            db = new AltranSIWalletContext();
            projectManagerRepository = new ProjectManagerRepository(db);
            userRepository = new UserRepository(db);
        }
        /// <summary>
        /// Get All ProjectManagers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<ProjectManager> projectManagers = await projectManagerRepository.FindAll().ToListAsync();
            return Ok(projectManagers);
        }

        /// <summary>
        /// Get ProjectManager By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            ProjectManager projectManager = await projectManagerRepository.FindByCondition(item => item.Id == id).FirstOrDefaultAsync();
            if (projectManager == null)
                return Content(HttpStatusCode.NotFound, "Project Manager not found");
            return Ok(projectManager);
        }

        /// <summary>
        /// Create new Project Manager
        /// </summary>
        /// <param name="projectManager"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Create(ProjectManager projectManager)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (projectManager.User == null)
                return BadRequest("User can not be null");
            userRepository.Create(projectManager.User);
            projectManagerRepository.Create(projectManager);
            await db.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Update Data of Project Manager
        /// </summary>
        /// <param name="projectManager"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody]ProjectManager projectManager)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            projectManagerRepository.Update(projectManager);
            userRepository.Update(projectManager.User);

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                ProjectManager projectManagerToUpdate = await projectManagerRepository.FindByCondition(item => item.Id == projectManager.Id).FirstOrDefaultAsync();
                if (projectManagerToUpdate == null)
                    return Content(HttpStatusCode.NotFound, "Project Manager not found");
                User userToUpdate = await userRepository.FindByCondition(item => item.Id == projectManager.UserId).FirstOrDefaultAsync();
                if (userToUpdate == null)
                    return Content(HttpStatusCode.NotFound, "User not found");
                throw;
            }
            return Ok();
        }

        /// <summary>
        /// Remove Project Manager By Id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            ProjectManager projectManager = await projectManagerRepository.FindByCondition(item => item.Id == id).FirstOrDefaultAsync();
            if (projectManager == null)
                return Content(HttpStatusCode.NotFound, "Manager not found");
            User user = await userRepository.FindByCondition(item => item.Id == projectManager.UserId).FirstOrDefaultAsync();
            if (user == null)
                return Content(HttpStatusCode.NotFound, "User not found");
            projectManagerRepository.Delete(projectManager);
            userRepository.Delete(user);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
