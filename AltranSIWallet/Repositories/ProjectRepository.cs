using AltranSIWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>
    {
        public ProjectRepository(AltranSIWalletContext altranSIWalletContext) : base(altranSIWalletContext)
        {
        }
    }
}