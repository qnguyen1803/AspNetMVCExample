using AltranSIWallet.Models;
using AltranSIWallet.Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AltranSIWallet.ModelsDto
{
    public class ConsultantAddDto
    {
        [Required]
        public ELevels Level { get; set; }
        public string SkillsFile { get; set; }
        public int? ProjectId { get; set; }
        public int? ManagerId { get; set; }
        public virtual UserAddDto UserAddDto { get; set; }
    }
}