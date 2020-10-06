using System;
using System.Collections.Generic;
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
        public string UserId { get; set; }
        #endregion

        #region NavigationProperties
        public User User { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        #endregion
    }
}