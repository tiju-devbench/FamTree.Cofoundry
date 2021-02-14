using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cofoundry.Domain;
using Cofoundry.Domain.CQS;
using Cofoundry.Web;
using FamTree.Cofoundry.Domain.Domain.Families;

namespace FamTree.Cofoundry.WebApp.API
{
    [Route("api/families")]
    [AutoValidateAntiforgeryToken]
    public class FamiliesApiController : ControllerBase
    {        
        private readonly IQueryExecutor _queryExecutor;
        private readonly IApiResponseHelper _apiResponseHelper;
        public FamiliesApiController(IQueryExecutor queryExecutor,
            IApiResponseHelper apiResponseHelper)
        {
            _queryExecutor = queryExecutor;
            _apiResponseHelper = apiResponseHelper;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] SearchFamilySummariesQuery query)
        {
            if (query == null) query = new SearchFamilySummariesQuery();
            var results = await _queryExecutor.ExecuteAsync(query);
            return
                _apiResponseHelper.SimpleQueryResponse(this, results);
        }
    }
}
