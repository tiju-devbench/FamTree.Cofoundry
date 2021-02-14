using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain;
using System.ComponentModel.DataAnnotations;
using FamTree.Cofoundry.Domain.Domain.Persons;

namespace FamTree.Cofoundry.Domain.Domain.Families
{
    class FamilyDataModel : ICustomEntityDataModel
    {
        [Display(Description = "Family Name")]
        public string Name { get; set; }

        [Display(Description = "A brief story of the family")]
        public string Description { get; set; }

        [Display(Description = "Location/native")]
        public string Address { get; set; }

        [Display(Name = "Wedding anniversary", Description = "Date of wedding anniversary")]
        [Date]
        public DateTime WeddingAnniversary { get; set; }

        [Display(Name = "Parents", Description = "Parents")]
        [CustomEntityCollection(PersonCustomEntityDefinition.DefinitionCode)]
        public ICollection<int> ParentIds { get; set; }

        [Display(Name = "Children", Description = "Children of the family")]
        [CustomEntityCollection(PersonCustomEntityDefinition.DefinitionCode)]
        public ICollection<int> MemberIds { get; set; }

        [Display(Name = "Display Image", Description = "Image Thumbnail for the family")]
        [Image("Family")]
        public int? DisplayImageId { get; set; }

        [Display(Name = "Album", Description = "The top image will be the main image that displays in the grid")]
        [ImageCollection]
        public ICollection<int> ImageAssetIds { get; set; }
    }
}
