using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamTree.Cofoundry.Domain.Domain.Families
{
    class FamilyCustomEntityDefinition : ICustomEntityDefinition<FamilyDataModel>
        , ICustomizedTermCustomEntityDefinition
    {
        public const string DefinitionCode = "FAMLIS";
        public string CustomEntityDefinitionCode => DefinitionCode;

        public string Name => "Family";

        public string NamePlural => "Families";

        public string Description => "Families are not built with bricks; but with hearts";

        public bool ForceUrlSlugUniqueness => false;

        public bool ForceUrlSlugUniquenes => false;

        public bool HasLocale => false;

        public bool AutoGenerateUrlSlug => true;

        public bool AutoPublish => false;

        public Dictionary<string, string> CustomTerms => new Dictionary<string, string>()
        {
            { CustomizableCustomEntityTermKeys.Title, "Name" }
        };
    }
}
