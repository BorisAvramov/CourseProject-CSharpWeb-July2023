using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data.Models
{
    [Comment("mapping table for many to many relation -> a company could have offices in many towns and many companies could have an office in a town")]
    public class CompanyTown
    {
        [Required]
        public bool IsDeleted { get; set; }


        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;



        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public virtual Town Town { get; set; } = null!;



    }
}
