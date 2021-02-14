using Cofoundry.Core;
using Cofoundry.Domain;
using Cofoundry.Domain.CQS;
using FamTree.Cofoundry.Domain.Data;
using FamTree.Cofoundry.Domain.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamTree.Cofoundry.Domain.Domain.Families
{
    class SearchFamilySummariesQueryHandler : IQueryHandler<SearchFamilySummariesQuery, PagedQueryResult<FamilySummary>>
        , IIgnorePermissionCheckHandler
    {
       // private readonly FamTreeDBContext _dbContext;
        private readonly IContentRepository _contentRepository;
        public SearchFamilySummariesQueryHandler(
            IContentRepository contentRepository
            )
        {
           // _dbContext = dbContext;
            _contentRepository = contentRepository;
        }
        public async Task<PagedQueryResult<FamilySummary>> ExecuteAsync(SearchFamilySummariesQuery query, IExecutionContext executionContext)
        {
            var customEntityQuery = new SearchCustomEntityRenderSummariesQuery();
            customEntityQuery.CustomEntityDefinitionCode = FamilyCustomEntityDefinition.DefinitionCode;
            customEntityQuery.PageSize = query.PageSize;
            customEntityQuery.PageNumber = query.PageNumber;
            customEntityQuery.PublishStatus = PublishStatusQuery.Published;
            customEntityQuery.SortBy = CustomEntityQuerySortType.CreateDate;

            var familyCustomEntities = await _contentRepository
                .CustomEntities()
                .Search()
                .AsRenderSummaries(customEntityQuery)
                .ExecuteAsync();

            var allMainImages = await GetMainImages(familyCustomEntities);
            var allParents = await GetParents(familyCustomEntities);

            return MapFamily(familyCustomEntities,allMainImages, allParents);


        }

        private async Task<ICollection<CustomEntityRenderSummary>> GetParents(PagedQueryResult<CustomEntityRenderSummary> familyCustomEntities)
        {
            var ParentIds = familyCustomEntities
                              .Items
                              .Select(i => ((FamilyDataModel)i.Model).ParentIds);


            return  await _contentRepository.CustomEntities().GetByDefinitionCode(PersonCustomEntityDefinition.DefinitionCode).AsRenderSummary().ExecuteAsync();
        }

        private PagedQueryResult<FamilySummary> MapFamily(PagedQueryResult<CustomEntityRenderSummary> familyCustomEntities, IDictionary<int, ImageAssetRenderDetails> allMainImages, ICollection<CustomEntityRenderSummary> allParents)
        {
            var families = new List<FamilySummary>(familyCustomEntities.Items.Count());
            foreach (var entity in familyCustomEntities.Items)
            {
                var model = (FamilyDataModel)entity.Model;
                var family = new FamilySummary();
                family.FamilyId = entity.CustomEntityId;
                family.Address = model.Address;
                family.Description = model.Description;
                family.MastheadTitle = getMastHeadTitle(allParents);
                family.WeddingAnniversary = model.WeddingAnniversary;
                if (model.DisplayImageId!= null)
                {
                    family.DisplayImage = allMainImages.GetOrDefault(model.DisplayImageId);
                }
                families.Add(family);
            }
            return familyCustomEntities.ChangeType(families);
        }

        private string getMastHeadTitle(ICollection<CustomEntityRenderSummary> allParents)
        {
            StringBuilder title = new StringBuilder();
            title.AppendJoin(" & ", allParents.Select(p => ((PersonDataModel)p.Model).FName));
            return title.ToString();
        }

        private Task<IDictionary<int, ImageAssetRenderDetails>> GetMainImages(PagedQueryResult<CustomEntityRenderSummary> familyCustomEntities)
        {
            var imageAssetIds = familyCustomEntities
                 .Items
                 .Select(i => (FamilyDataModel)i.Model)
                 .Where(m => m.DisplayImageId != null)
                 .Select(m => m.DisplayImageId.Value)
                 .Distinct();

            return _contentRepository
                .ImageAssets()
                .GetByIdRange(imageAssetIds)
                .AsRenderDetails()
                .ExecuteAsync();
        }
    }
}
