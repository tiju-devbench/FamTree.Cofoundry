using Cofoundry.Domain;
using Cofoundry.Domain.CQS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FamTree.Cofoundry.Domain.Domain.Members.Queries
{
    class GetCurrentMemberSummaryQueryHandler : IQueryHandler<GetCurrentMemberSummaryQuery, MemberSummary>
        , IIgnorePermissionCheckHandler
    {
        private readonly IContentRepository _contentRepository;
        public GetCurrentMemberSummaryQueryHandler(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }
        public async Task<MemberSummary> ExecuteAsync(GetCurrentMemberSummaryQuery query, IExecutionContext executionContext)
        {
            if (!IsLoggedInMember(executionContext.UserContext)) return null;

            var user = await _contentRepository
                .Users()
                .GetCurrent()
                .AsMicroSummary()
                .ExecuteAsync();

            return new MemberSummary()
            {
                UserId = user.UserId,
                Name = user.GetFullName()
            };

        }
        private bool IsLoggedInMember(IUserContext userContext)
        {
            return userContext.UserId.HasValue && userContext.UserArea.UserAreaCode == MemberUserArea.MemberUserAreaCode;
        }

    }
}
