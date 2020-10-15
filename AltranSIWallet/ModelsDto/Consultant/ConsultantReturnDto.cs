using AltranSIWallet.Models;
using AltranSIWallet.Shared.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.ModelsDto
{
    public class ConsultantReturnDto
    {
        #region Properties
        public int Id { get; set; }
        #endregion

        #region NavigationProperties
        public EnumModel Level { get; set; }
        //public string LevelDescription { get; set; }
        public string SkillsFile { get; set; }
        #endregion

        #region NavigationProperties
        public User User { get; set; }
        public Project Project { get; set; }
        public Manager Manager { get; set; }
        #endregion
    }
}