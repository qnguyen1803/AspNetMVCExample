using AltranSIWallet.Models;
using System.Collections.Generic;

namespace AltranSIWallet.ModelsDto
{
    public class ManagerUpdateDto
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<int> ConsultantsId { get; set; }
    }
}