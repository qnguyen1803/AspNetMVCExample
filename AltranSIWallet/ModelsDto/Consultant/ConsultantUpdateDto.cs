using AltranSIWallet.Models;
using AltranSIWallet.Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AltranSIWallet.ModelsDto
{
    public class ConsultantUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public ELevels Level { get; set; }
        public string SkillsFile { get; set; }
        public int? ProjectId { get; set; }
        public int? ManagerId { get; set; }
        public virtual User User { get; set; }
    }
}