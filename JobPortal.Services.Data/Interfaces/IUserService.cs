using JobPortal.Web.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Data.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Get Full Name of User by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        Task<string> GetFullNameById(string userId);


        /// <summary>
        /// Get all Users of Application
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<UserViewModel>> All(string userId);


    }
}
