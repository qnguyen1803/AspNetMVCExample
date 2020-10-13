using AltranSIWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Repositories
{
    public class ProjectManagerRepository : RepositoryBase<ProjectManager>
    {
        public ProjectManagerRepository(AltranSIWalletContext altranSIWalletContext) : base(altranSIWalletContext)
        {
        }
    }
}