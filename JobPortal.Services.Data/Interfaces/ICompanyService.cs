using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Data.Interfaces
{
    public interface ICompanyService
    {
        Task<bool> CompanyExistsByUserId(string userId);

    }
}
