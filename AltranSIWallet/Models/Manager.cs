using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string UserGuid { get; set; }
        public virtual ICollection<Consultant> Consultants { get; set; }
    }
}