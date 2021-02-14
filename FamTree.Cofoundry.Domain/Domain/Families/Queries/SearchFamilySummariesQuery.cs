using System;
using System.Collections.Generic;
using System.Text;
using Cofoundry.Domain;
using Cofoundry.Domain.CQS;

namespace FamTree.Cofoundry.Domain.Domain.Families
{
    public class SearchFamilySummariesQuery : SimplePageableQuery
        , IQuery<PagedQueryResult<FamilySummary>>
    {
    }
}
