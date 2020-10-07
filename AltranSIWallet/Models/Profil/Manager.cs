using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class Manager: Profil
    {
        #region NavigationProperties
        public virtual ICollection<Consultant> Consultants { get; set; }
        #endregion
    }
}