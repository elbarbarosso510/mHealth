using ICD.Base.Domain.Entity;
using ICD.Base.Domain.View;
using ICD.Base.RepositoryContract;
using ICD.Framework.Data.Repository;
using ICD.Framework.DataAnnotation;
using ICD.Framework.Model;
using ICD.Framework.QueryDataSource;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ICD.Framework.Extensions;

namespace ICD.Base.Repository
{
    [Dependency(typeof(ITaxRepository))]
    public class TaxRepository : BaseRepository<TaxEntity, int>, ITaxRepository
    {
        public async Task<ListQueryResult<TaxView>> GetTaxAsync(QueryDataSource<TaxView> searchQuery, int languageRef)
        {
            var finalResult = new ListQueryResult<TaxView>
            {
                Entities = new List<TaxView>()
            };

            var queryResult = from t in GenericRepository.Query<TaxEntity>()
                              join tl in GenericRepository.Query<TaxLanguageEntity>()
                              on t.Key equals tl.TaxRef
                              where tl.LanguageRef == languageRef
                              select new TaxView
                              {
                                  Key = t.Key,
                                  LanguageRef = tl.LanguageRef,
                                  TaxRef = tl.TaxRef,
                                  Alias = t.Alias,
                                  IsActive = t.IsActive,
                                  TaxPercent = t.TaxPercent,
                                  _Description = tl._Description,
                                  _Title = tl._Title
                              };

            var result = await queryResult.ToListQueryResultAsync(searchQuery);

            finalResult = result;

            return finalResult;
        }
    }
}
