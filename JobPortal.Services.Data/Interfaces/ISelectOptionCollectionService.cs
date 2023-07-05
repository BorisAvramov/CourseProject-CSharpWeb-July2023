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
        Task<IEnumerable<Town>> GetTowns();
        Task<IEnumerable<ProgrammingLanguage>> GetProgrammingLanguages();
        Task<IEnumerable<Level>> GetLevels();
        Task<IEnumerable<JobType>> GetJobTypes();

    }
}
