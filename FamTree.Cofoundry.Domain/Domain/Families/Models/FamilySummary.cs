using Cofoundry.Domain;
using System;
using System.Collections.Generic;

namespace FamTree.Cofoundry.Domain.Domain.Families
{
    public class FamilySummary
    {
        public int FamilyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime WeddingAnniversary { get; set; }
        public string MastheadTitle { get; set; }
        public ImageAssetRenderDetails DisplayImage { get; set; }
    }
}