using JobPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Data.Interfaces
{
    public interface ISelectOptionCollectionService
    {
        /// <summary>
        /// Get all town entities!
        /// </summary>
        /// <returns>IEnumerable<Town></returns>
        Task<IEnumerable<Town>> GetTowns();

        /// <summary>
        /// Get all ProgrammingLanguage entities!
        /// </summary>
        /// <returns>IEnumerable<ProgrammingLanguage></returns>
        Task<IEnumerable<ProgrammingLanguage>> GetProgrammingLanguages();

        /// <summary>
        /// Get all Level entities!
        /// </summary>
        /// <returns>IEnumerable<Level></returns>
        Task<IEnumerable<Level>> GetLevels();

        /// <summary>
        /// Get all JobType entities!
        /// </summary>
        /// <returns>IEnumerable<JobType></returns>
        Task<IEnumerable<JobType>> GetJobTypes();

    }
}
