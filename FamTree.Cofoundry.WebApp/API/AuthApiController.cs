using System;
using System.Collections.Generic;
using System.Linq;
using Cofoundry.Domain.CQS;
using Cofoundry.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Antiforgery;
using FamTree.Cofoundry.Domain.Domain.Members;
using Microsoft.AspNetCore.Cors;

namespace FamTree.Cofoundry.WebApp.API
{
    [Route("api/auth")]
    [AutoValidateAntiforgeryToken]
    public class AuthApiController : ControllerBase
    {
        private readonly IApiResponseHelper _apiResponseHelper;
        private readonly IAntiforgery _antiforgery;
        private readonly IQueryExecutor _queryExecutor;
        public AuthApiController(
            IApiResponseHelper apiResponseHelper,
            IAntiforgery antiforgery,
            IQueryExecutor queryExecutor
            )
        {
            _apiResponseHelper = apiResponseHelper;
            _antiforgery = antiforgery;
            _queryExecutor = queryExecutor;
        }
        [HttpGet("session")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> GetAuthSession()
        {
            var member = await _queryExecutor.ExecuteAsync(new GetCurrentMemberSummaryQuery());
            var token = _antiforgery.GetAndStoreTokens(HttpContext);

            var sessionInfo = new
            {
                Member = member,
                AntiForgeryToken = token.RequestToken
            };
        return  _apiResponseHelper.SimpleQueryResponse(this, sessionInfo);
        }

        [HttpPost("register")]
        [EnableCors("AllowAll")]
        public Task<IActionResult> Register([FromBody] RegisterMemberAndLogInCommand command)
        {
            return _apiResponseHelper.RunCommandAsync(this, command);
        }

        [HttpPost("login")]
        [EnableCors("AllowAll")]
        public Task<IActionResult> Login([FromBody] LogMemberInCommand command)
        {
            return _apiResponseHelper.RunCommandAsync(this, command);
        }

        [HttpPost("sign-out")]
        [EnableCors("AllowAll")]
        public Task<IActionResult> SignOut()
        {
            var command = new LogMemberOutCommand();
            return _apiResponseHelper.RunCommandAsync(this, command);
        }

    }
}
