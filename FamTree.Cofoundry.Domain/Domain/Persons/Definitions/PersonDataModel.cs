using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain;
using System.ComponentModel.DataAnnotations;

namespace FamTree.Cofoundry.Domain.Domain.Persons
{
    internal class PersonDataModel : ICustomEntityDataModel
    {
        [Display(Description = "First Name")]
        public string FName { get; set; }

        [Display(Description = "Last Name")]
        public string LName { get; set; }

        [Display(Description = "Gender")]
        [RadioList(typeof(GenderType))]
        public GenderType Gender { get; set; }

        [Display(Description = "A brief story of the person")]
        public string Description { get; set; }

        [Display(Name = "Date of birth", Description = "Date of Birth")]
        [Date]
        public DateTime DoB { get; set; }

        [Display(Description = "Address")]
        public string Address { get; set; }

        [Display(Name = "Display Image", Description = "Image Thumbnail for the family")]
        [Image("Avatar")]
        public int? DisplayImageId { get; set; }

        [Display(Name = "Album", Description = "The top image will be the main image that displays in the grid")]
        [ImageCollection]
        public ICollection<int> ImageAssetIds { get; set; }

        public enum GenderType
        {
            Male,
            Female
        }
    }
}