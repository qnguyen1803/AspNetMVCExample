using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class Consultant
    {
        #region Properties
        public int Id { get; set; }
        public Enum Level { get; set; }
        public string SkillsFile { get; set; }
        #endregion

        #region foreignKeys
        public string UserId { get; set; }
        public string ProjectId { get; set; }
        public string ManagerId { get; set; }
        #endregion

        #region NavigationProperties
        public virtual Project Project{ get; set; }
        public virtual User User { get; set; }
        public virtual Manager Manager { get; set; }
        #endregion

    }
}