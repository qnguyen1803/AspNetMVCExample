using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class Profil
    {
        #region Properties
        public int Id { get; set; }
        #endregion

        #region ForeignKeys
        public int UserId { get; set; }
        #endregion

        #region NavigationProperties
        public virtual User User { get; set; }
        #endregion
    }
}