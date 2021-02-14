using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamTree.Cofoundry.Domain.Domain.Persons
{
    internal class PersonCustomEntityDefinition : ICustomEntityDefinition<PersonDataModel>
        , ICustomizedTermCustomEntityDefinition
    {
        public const string DefinitionCode = "PRSONS";
        public string CustomEntityDefinitionCode => DefinitionCode;

        public string Name => "Person";

        public string NamePlural => "Persons";

        public string Description => "Memebers of the family";

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