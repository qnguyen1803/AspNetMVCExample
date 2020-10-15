using AltranSIWallet.Models;
using AltranSIWallet.ModelsDto;
using AltranSIWallet.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Mappings
{
    public static partial class Mappings
    {
        #region ToDto
        public static ConsultantReturnDto ConsultantToConsultantReturnDto(this Consultant consultant)
        {
            if (consultant != null)
            {
                return new ConsultantReturnDto
                {
                    Id = consultant.Id,
                    Level = new EnumModel
                    {
                        Value = (int) consultant.Level,
                        Description = EnumHelper.GetDescription(consultant.Level)
                    },
                    SkillsFile = consultant.SkillsFile,
                    User = consultant.User,
                    Project = consultant.Project,
                    Manager = consultant.Manager
                };
            }
            return null;
        }
        #endregion

        #region ToDomain
        public static Consultant ConsultantAddDtoToConsultant(this ConsultantAddDto consultantAddDto)
        {
            if (consultantAddDto != null)
            {
                return new Consultant
                {
                    Id = 0,
                    Level = consultantAddDto.Level,
                    Manager = null,
                    ManagerId = consultantAddDto.ManagerId,
                    Project = null,
                    UserId = null,
                    ProjectId = consultantAddDto.ProjectId,
                    SkillsFile = consultantAddDto.SkillsFile,
                    User = consultantAddDto.UserAddDto.UserAddDtoToUser()
                };
            }
            return null;
        }

        public static Consultant ConsultantUpdateDtoToConsultant(this ConsultantUpdateDto consultantAddDto)
        {
            if (consultantAddDto != null)
            {
                return new Consultant
                {
                    Id = consultantAddDto.Id,
                    Level = consultantAddDto.Level,
                    Manager = null,
                    ManagerId = consultantAddDto.ManagerId,
                    Project = null,
                    UserId = consultantAddDto.User.Id,
                    ProjectId = consultantAddDto.ProjectId,
                    SkillsFile = consultantAddDto.SkillsFile,
                    User = null
                };
            }
            return null;
        }
        #endregion
    }
}