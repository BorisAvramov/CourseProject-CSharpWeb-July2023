﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Data.Interfaces
{
    public interface IApplicantService
    {
        Task<bool> ApplicantExistsByUserId(string userId);

    }
}
