using AltranSIWallet.Models;
using AltranSIWallet.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Mappings
{
    public static partial class Mappings
    {
        public static ManagerReturnDto ManagerToManagerReturnDto(this Manager manager)
        {
            if(manager != null){
                List<ConsultantReturnDto> consultantReturnDtoList = new List<ConsultantReturnDto>();
                if(manager.Consultants.Count() > 0)
                {
                    foreach(Consultant consultant in manager.Consultants)
                    {
                        consultantReturnDtoList.Add(consultant.ConsultantToConsultantReturnDto());
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

        public static Manager ManagerAddDtoToManager(this ManagerAddDto managerAddDto)
        {
            if(managerAddDto != null){
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
    }
}