using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamTree.Cofoundry.Domain.Domain.Members
{
    class MemberRole : IRoleDefinition
    {
        public const string MemberRoleCode = "MEM";
        public string Title { get { return "Member"; } }

        public string RoleCode { get { return MemberRoleCode; } }
        public string UserAreaCode { get { return MemberUserArea.MemberUserAreaCode; } }
    }
}
