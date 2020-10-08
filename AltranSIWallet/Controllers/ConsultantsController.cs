using AltranSIWallet.Models;
using AltranSIWallet.ModelsDto.Consultant;
using System;
using System.Collections.Generic;
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
        //public async Task<IHttpActionResult> GetListByLevels(int level)
        //{
        //    var consultants = db.Consultants.FindAsync();
        //    return Ok();
        //}

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
                return NotFound();
            return Ok(consultant);
        }

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
    }
}
