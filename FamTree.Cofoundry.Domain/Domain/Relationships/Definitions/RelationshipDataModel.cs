using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain;
using System.ComponentModel.DataAnnotations;
using FamTree.Cofoundry.Domain.Domain.Persons;

namespace FamTree.Cofoundry.Domain.Domain.Relationships
{
    internal class RelationshipDataModel : ICustomEntityDataModel
    {
        [Display(Description = "Person 1")]
        [CustomEntity(PersonCustomEntityDefinition.DefinitionCode)]
        public int Person1 { get; set; }
        [Display(Description = "Person 2")]
        [CustomEntity(PersonCustomEntityDefinition.DefinitionCode)]
        public int Person2 { get; set; }

        [Display(Description = "Relation")]
        [SelectList(typeof(RelationshipType))]
        public RelationshipType Relation { get; set; }

        public enum RelationshipType
        {
            Father,
            Mother,
            Son,
            Daughter,
            Niece,
            Nephew,
            GrandFather,
            GrandMother
        }
    }
}