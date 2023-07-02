using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Data.Models
{
    [Comment("This is identity user for the app")]
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }


        [Required]
        public bool IsDeleted { get; set; }



    }
}