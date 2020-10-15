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
    public class ProjectsController : ApiController
    {
        private AltranSIWalletContext db;
        private readonly ProjectRepository projectRepository;

        public ProjectsController()
        {
            db = new AltranSIWalletContext();
            projectRepository = new ProjectRepository(db);
        }
        /// <summary>
        /// Get All Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Project> projects = await projectRepository.FindAll().ToListAsync();
            return Ok(projects);
        }

        /// <summary>
        /// Get Project By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Project project = await projectRepository.FindByCondition(item => item.Id == id).FirstOrDefaultAsync();
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
            projectRepository.Create(project);
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

            projectRepository.Update(project);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                Project projectToUpdate = await projectRepository.FindByCondition(item => item.Id == project.Id).FirstOrDefaultAsync(); 
                if (projectToUpdate == null)
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
            Project project = await projectRepository.FindByCondition(item => item.Id == id).FirstOrDefaultAsync();
            if (project == null)
                return Content(HttpStatusCode.NotFound, "Project not found");
            projectRepository.Delete(project);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
