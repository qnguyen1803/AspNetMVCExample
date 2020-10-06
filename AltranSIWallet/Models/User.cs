﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class User
    {
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Salary { get; set; }
        public DateTime IntegrationDate { get; set; }
        #endregion
    }
}