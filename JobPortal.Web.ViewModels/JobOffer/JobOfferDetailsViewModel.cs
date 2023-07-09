using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JobPortal.Web.ViewModels.JobOffer
{
    public class JobOfferDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string CompanyImageUrl { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string CompanyId { get; set; } = null!;
        public string CompanyPhone { get; set; } = null!;
        public string CompanyEmail { get; set; } = null!;

    }
}
