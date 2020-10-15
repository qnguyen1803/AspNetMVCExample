using AltranSIWallet.Mappings;
using AltranSIWallet.Models;
using AltranSIWallet.ModelsDto;
using AltranSIWallet.Repositories;
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
        private AltranSIWalletContext db;
        private readonly ConsultantRepository consultantRepository;
        private readonly UserRepository userRepository;

        public ConsultantsController()
        {
            db = new AltranSIWalletContext();
            consultantRepository = new ConsultantRepository(db);
            userRepository = new UserRepository(db);
        }
        /// <summary>
        /// Get All Consultants
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Consultant> consultants = await consultantRepository.FindAll().ToListAsync();
            return Ok(consultants.Select(item => item.ConsultantToConsultantReturnDto()));
        }

        /// <summary>
        /// Get List Consultants By Level 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> GetListByLevels(ELevels level)
        {
            List<Consultant> consultants = await consultantRepository.FindByCondition(item => item.Level == level).ToListAsync();
            return Ok(consultants.Select(item => item.ConsultantToConsultantReturnDto()));
        }

        /// <summary>
        /// Get Consultant By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Consultant consultant = await consultantRepository.FindByCondition(item => item.Id == id).FirstOrDefaultAsync();
            if (consultant == null)
                return Content(HttpStatusCode.NotFound, "Consultant not found");

            return Ok(consultant.ConsultantToConsultantReturnDto());
        }

        /// <summary>
        /// Create new Consultant
        /// </summary>
        /// <param name="consultant"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]ConsultantAddDto consultantAddDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (consultantAddDto.UserAddDto == null)
                return BadRequest("User can not be null");
            userRepository.Create(consultantAddDto.UserAddDto.UserAddDtoToUser());
            consultantRepository.Create(consultantAddDto.ConsultantAddDtoToConsultant());
            await db.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Update a consultant
        /// </summary>
        /// <param name="consultant"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Update([FromBody]ConsultantUpdateDto consultantUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            userRepository.Update(consultantUpdateDto.User);
            consultantRepository.Update(consultantUpdateDto.ConsultantUpdateDtoToConsultant());
            try {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                Consultant consultantToUpdate = await consultantRepository.FindByCondition(item => item.Id == consultantUpdateDto.Id).FirstOrDefaultAsync();
                if (consultantToUpdate == null)
                    return Content(HttpStatusCode.NotFound, "Consultant not found");
                User userToUpdate = await userRepository.FindByCondition(item => item.Id == consultantUpdateDto.User.Id).FirstOrDefaultAsync();
                if (userToUpdate == null)
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
            Consultant consultant = await consultantRepository.FindByCondition(item => item.Id == id).FirstAsync();
            if (consultant == null)
                return Content(HttpStatusCode.NotFound, "Consultant not found");
            User user = await userRepository.FindByCondition(item => item.Id == consultant.UserId).FirstAsync();
            if (user == null)
                return Content(HttpStatusCode.NotFound, "User not found");
            consultantRepository.Delete(consultant);
            userRepository.Delete(user);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
