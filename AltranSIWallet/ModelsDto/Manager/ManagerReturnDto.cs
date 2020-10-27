using AltranSIWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.ModelsDto
{
    public class ManagerReturnDto
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<ConsultantReturnDto> Consultants { get; set; }
    }
}