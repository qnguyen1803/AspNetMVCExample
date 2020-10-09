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
    public class ProjectsController : ApiController
    {
        private AltranSIWalletContext db = new AltranSIWalletContext();

        /// <summary>
        /// Get All Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IQueryable<Project> GetAll()
        {
            return db.Projects;
        }

        /// <summary>
        /// Get Project By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
                return Content(HttpStatusCode.NotFound, "Project not found");
            return Ok(project);
        }

        /// <summary>
        /// Create new Project 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Create(Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            db.Projects.Add(project);
            await db.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Update Data of Project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody]Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Entry(project).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                int countProject = db.Projects.Count(m => m.Id == project.Id);
                if (countProject == 0)
                    return Content(HttpStatusCode.NotFound, "Project not found");
                throw;
            }

            return Ok();
        }

        /// <summary>
        /// Remove Project By Id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
                return Content(HttpStatusCode.NotFound, "Project not found");
            db.Projects.Remove(project);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
