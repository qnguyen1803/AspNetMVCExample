using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class Consultant
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        public int Level { get; set; }
        public string SkillsFile { get; set; }
        #endregion

        #region foreignKeys
        [Required]
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public int ManagerId { get; set; }
        #endregion

        #region NavigationProperties
        public virtual Project Project{ get; set; }
        public virtual User User { get; set; }
        public virtual Manager Manager { get; set; }
        #endregion

    }
}