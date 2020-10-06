using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string ProjectManagerGuid { get; set; }
        public virtual ICollection<Consultant> Consultants { get; set; }
    }
}