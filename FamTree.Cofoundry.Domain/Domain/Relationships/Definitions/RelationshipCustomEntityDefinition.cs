using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamTree.Cofoundry.Domain.Domain.Relationships
{
    internal class RelationshipCustomEntityDefinition : ICustomEntityDefinition<RelationshipDataModel>
        , ICustomizedTermCustomEntityDefinition
    {
        public const string DefinitionCode = "RLNSHP";
        public string CustomEntityDefinitionCode => DefinitionCode;

        public string Name => "Relationship";

        public string NamePlural => "Relationships";

        public string Description => "Family Relations are defined here";

        public bool ForceUrlSlugUniqueness => false;

        public bool HasLocale => false;

        public bool AutoGenerateUrlSlug => true;

        public bool AutoPublish => false;

        public Dictionary<string, string> CustomTerms => new Dictionary<string, string>()
        {
            { CustomizableCustomEntityTermKeys.Title, "Name" }
        };
    }
}