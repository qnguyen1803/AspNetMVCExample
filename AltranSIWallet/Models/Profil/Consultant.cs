﻿using AltranSIWallet.Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class Consultant : Profil
    {
        #region Properties
        [Required]
        public ELevels Level { get; set; }
        public string SkillsFile { get; set; }
        #endregion

        #region foreignKeys
        public int? ProjectId { get; set; }
        public int? ManagerId { get; set; }
        #endregion

        #region NavigationProperties
        public virtual Project Project { get; set; }
        public virtual Manager Manager { get; set; }
        #endregion
    }
}