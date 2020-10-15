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
                return new ManagerReturnDto
                {
                    Id = manager.Id,
                    Consultants = manager.Consultants,
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