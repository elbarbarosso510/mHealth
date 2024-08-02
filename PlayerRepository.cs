using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICD.Base.Domain.Entity;
using ICD.Base.RepositoryContract;
using ICD.Framework.Data.Repository;
using ICD.Framework.DataAnnotation;
using ICD.Framework.Extensions;
using ICD.Framework.Model;
using ICD.Framework.QueryDataSource;

namespace ICD.Base.Repository
{
    [Dependency(typeof(IPlayerRepository))]
    public class PlayerRepository : BaseRepository<PlayerEntity, int>, IPlayerRepository
    {
        public async Task<ListQueryResult<PlayerEntity>> GetAllPlayersAsync(QueryDataSource<PlayerEntity> queryDataSource)
        { 
            var Result = new ListQueryResult<PlayerEntity>
            {
                Entities = new List<PlayerEntity>()
            };

            var queryResult = from pt in GenericRepository.Query<PlayerEntity>()
                select pt;
            Result = await queryResult.ToListQueryResultAsync(queryDataSource);
            return Result;
        }
    }
}
