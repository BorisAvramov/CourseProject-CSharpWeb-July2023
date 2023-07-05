using JobPortal.Data;
using JobPortal.Data.Models;
using JobPortal.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Data
{
    public class SelectOptionCollectionService : ISelectOptionCollectionService
    {

        private readonly JobPortalDbContext dbContext;

        public SelectOptionCollectionService(JobPortalDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }



        public async Task<IEnumerable<JobType>> GetJobTypes()
        {
            return await dbContext
                            .JobTypes.ToListAsync();
        }

        public async Task<IEnumerable<Level>> GetLevels()
        {
            return await dbContext
                            .Levels.ToListAsync();
        }

        public async Task<IEnumerable<ProgrammingLanguage>> GetProgrammingLanguages()
        {
            return await dbContext
                             .ProgrammingLanguages.ToListAsync();
        }

        public async Task<IEnumerable<Town>> GetTowns()
        {

            return await dbContext
                            .Towns.ToListAsync();
        }
    }
}
