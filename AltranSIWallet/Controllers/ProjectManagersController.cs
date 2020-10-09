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
    public class ProjectManagersController : ApiController
    {
        AltranSIWalletContext db = new AltranSIWalletContext();

        /// <summary>
        /// Get All ProjectManagers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IQueryable<ProjectManager> GetAll()
        {
            return db.ProjectManagers;
        }

        /// <summary>
        /// Get ProjectManager By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            ProjectManager projectManager = await db.ProjectManagers.FindAsync(id);
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
            db.Users.Add(projectManager.User);
            db.ProjectManagers.Add(projectManager);
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

            db.Entry(projectManager).State = EntityState.Modified;
            db.Entry(projectManager.User).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                int countProjectManager = db.ProjectManagers.Count(m => m.Id == projectManager.Id);
                int countUser = db.Users.Count(u => u.Id == projectManager.UserId);
                if (countProjectManager == 0)
                    return Content(HttpStatusCode.NotFound, "Project Manager not found");
                if (countUser == 0)
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
            ProjectManager projectManager = await db.ProjectManagers.FindAsync(id);
            if (projectManager == null)
                return Content(HttpStatusCode.NotFound, "Manager not found");
            User user = await db.Users.FindAsync(projectManager.UserId);
            if (user == null)
                return Content(HttpStatusCode.NotFound, "User not found");
            db.ProjectManagers.Remove(projectManager);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
