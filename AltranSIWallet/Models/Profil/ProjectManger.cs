using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class ProjectManger: Profil
    {
        #region NavigationProperties
        public virtual ICollection<Project> Projects { get; set; }
        #endregion
    }
}