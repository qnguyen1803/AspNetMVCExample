using AltranSIWallet.Models;
using AltranSIWallet.Shared.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.ModelsDto.Consultant
{
    public class ConsultantReturnDto
    {
        #region Properties
        public int Id { get; set; }
        #endregion

        #region NavigationProperties
        public ELevels Level { get; set; }
        //public string LevelDescription { get; set; }
        public string SkillsFile { get; set; }
        #endregion

        #region NavigationProperties
        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
        public virtual Manager Manager { get; set; }
        #endregion
    }
}