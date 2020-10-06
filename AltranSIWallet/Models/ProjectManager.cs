using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class ProjectManager
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}