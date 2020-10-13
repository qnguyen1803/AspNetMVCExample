using AltranSIWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(AltranSIWalletContext altranSIWalletContext) : base(altranSIWalletContext)
        {
        }
    }
}