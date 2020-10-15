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
        public static User UserAddDtoToUser(this UserAddDto userAddDto){
            if(userAddDto != null){
                return new User
                {
                    Id = 0,
                    Username = userAddDto.Username,
                    Email = userAddDto.Email,
                    EntryDate = userAddDto.EntryDate,
                    FirstName = userAddDto.FirstName,
                    LastName = userAddDto.LastName,
                    Password = userAddDto.Password,
                    Salary = userAddDto.Salary
                };
            }
            return null;
        }
    }
}