using AltranSIWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Repositories
{
    public class ConsultantRepository : RepositoryBase<Consultant>
    {
        public ConsultantRepository(AltranSIWalletContext altranSIWalletContext) : base(altranSIWalletContext)
        {
        }
    }
}