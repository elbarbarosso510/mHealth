using ICD.Base.Domain.Entity;
using ICD.Base.Domain.View;
using ICD.Base.RepositoryContract;
using ICD.Framework.Data.Repository;
using ICD.Framework.DataAnnotation;
using ICD.Framework.Model;
using ICD.Framework.QueryDataSource;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICD.Framework.Extensions;

namespace ICD.Base.Repository
{
    [Dependency(typeof(ISanaSupportInfoRepository))]
    public class SanaSupportInfoRepository : BaseRepository<SanaSupportInfoEntity, int>, ISanaSupportInfoRepository
    {
        public async Task<ListQueryResult<SanaSupportInfoView>> GetSanaSupportInfoAsync(QueryDataSource<SanaSupportInfoView> queryDataSource, int languageRef)
        {
            var result = new ListQueryResult<SanaSupportInfoView>
            {
                Entities = new List<SanaSupportInfoView>()
            };

            var queryResult = from ssi in GenericRepository.Query<SanaSupportInfoEntity>()
                              join pl in GenericRepository.Query<PersonLanguageEntity>() on ssi.PersonRef equals pl.PersonRef
                              where pl.LanguageRef == languageRef
                              select new SanaSupportInfoView
                              {
                                  Key = ssi.Key,
                                  PersonRef = ssi.PersonRef,
                                  FullName = pl.FullName,
                                  CreateDate = ssi.CreateDate,
                                  MobileNo = ssi.MobileNo,
                                  PhoneNo = ssi.PhoneNo,
                                  WhatsAppID = ssi.WhatsAppID
                              };

            result = await queryResult.ToListQueryResultAsync(queryDataSource);

            return result;
        }
    }
}
