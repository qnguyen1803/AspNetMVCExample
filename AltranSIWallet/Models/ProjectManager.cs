using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class ProjectManager
    {
        #region Properties
        public int Id { get; set; }
        #endregion

        #region ForeignKeys
        [Required]
        public int UserId { get; set; }
        #endregion

        #region NavigationProperties
        public User User { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        #endregion
    }
}