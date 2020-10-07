using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public int UserId { get; set; }
        #endregion

        #region NavigationProperties
        public virtual ICollection<Consultant> Consultants { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}