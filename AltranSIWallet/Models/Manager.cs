using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class Manager
    {
        #region Properties
        public int Id { get; set; }
        #endregion

        #region ForeignKeys
        public string UserId { get; set; }
        #endregion

        #region NavigationProperties
        public virtual ICollection<Consultant> Consultants { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}