using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamTree.Cofoundry.Domain.Domain.Members
{
    class MemberUserArea : IUserAreaDefinition
    {
        public const string MemberUserAreaCode = "FAM";
        public string UserAreaCode => MemberUserAreaCode;

        public string Name => "Fam Tree";

        public bool AllowPasswordLogin => true;

        public bool UseEmailAsUsername => true;

        public string LoginPath => "/";

        public bool IsDefaultAuthSchema => true;
    }
}
