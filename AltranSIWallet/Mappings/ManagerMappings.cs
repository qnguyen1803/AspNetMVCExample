using AltranSIWallet.Models;
using AltranSIWallet.ModelsDto;
using AltranSIWallet.ModelsDto.Consultant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Mappings
{
    public static partial class Mappings
    {
        #region ToDto
        public static ManagerReturnDto ManagerToManagerReturnDto(this Manager manager)
        {
            if(manager != null){
                List<ConsultantReturnWithoutManagerDto> consultantReturnDtoList = new List<ConsultantReturnWithoutManagerDto>();
                if(manager.Consultants.Count() > 0)
                {
                    foreach(Consultant consultant in manager.Consultants)
                    {
                        consultantReturnDtoList.Add(consultant.ConsultantToConsultantReturnWithoutManagerDto());
                    }
                }
                return new ManagerReturnDto
                {
                    Id = manager.Id,
                    Consultants = consultantReturnDtoList,
                    User = manager.User
                };
            }
            return null;
        }
        #endregion

        #region ToDomain
        public static Manager ManagerAddDtoToManager(this ManagerAddDto managerAddDto)
        {
            if (managerAddDto != null)
            {
                return new Manager
                {
                    Id = 0,
                    Consultants = null,
                    User = managerAddDto.UserAddDto.UserAddDtoToUser(),
                    UserId = null
                };
            }
            return null;
        }

        //public static Manager ManagerUpdateDtoToManager(this ManagerUpdateDto managerUpdateDto)
        //{

        //}
        #endregion

    }
}