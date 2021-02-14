using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamTree.Cofoundry.Domain.Domain.Members
{
    class MemberRoleInitializer : IRoleInitializer<MemberRole>
    {
        public IEnumerable<IPermission> GetPermissions(IEnumerable<IPermission> allPermissions)
        {
            return allPermissions
                .FilterToAnonymousRoleDefaults()
                ;
        }
    }
}
