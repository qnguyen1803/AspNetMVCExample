using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class Project
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region ForeignKeys
        [Required]
        public int ProjectManagerId { get; set; }
        #endregion

        #region NavigationProperties
        public virtual Project ProjectObj { get; set; }
        public virtual ICollection<Consultant> Consultants { get; set; }
        #endregion
    }
}