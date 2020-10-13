using AltranSIWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Repositories
{
    public class ManagerRepository : RepositoryBase<Manager>
    {
        public ManagerRepository(AltranSIWalletContext altranSIWalletContext) : base(altranSIWalletContext)
        {
        }
    }
}