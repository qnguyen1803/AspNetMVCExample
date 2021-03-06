﻿using AltranSIWallet.Models;
using AltranSIWallet.ModelsDto.Consultant;
using System.Collections.Generic;

namespace AltranSIWallet.ModelsDto
{
    public class ManagerReturnDto
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<ConsultantReturnWithoutManagerDto> Consultants { get; set; }
    }
}