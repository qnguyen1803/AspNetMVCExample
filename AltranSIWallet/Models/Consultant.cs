using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class Consultant
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string UserGuid { get; set }
        public decimal Salary { get; set; }
        public Enum Level { get; set; }
        public string SkillsFile { get; set; }
        public string ProjectGuid {get; set;}
    }
}