using ICD.Framework.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICD.Base.Domain.Entity;
using ICD.Base.RepositoryContract;
using ICD.Framework.DataAnnotation;
using ICD.Framework.Extensions;
using ICD.Framework.Model;
using ICD.Framework.QueryDataSource;

namespace ICD.Base.Repository
{
    [Dependency(typeof(ITeamRepository))]
    public class TeamRepository : BaseRepository<TeamEntity, int>, ITeamRepository
    {
        public async Task<ListQueryResult<TeamEntity>> GetAllTeamsAsync(QueryDataSource<TeamEntity> queryDataSource)
        {
            var Result = new ListQueryResult<TeamEntity>
            {
                Entities = new List<TeamEntity>()
            };

            var queryResult = from pt in GenericRepository.Query<TeamEntity>()
                select pt;

            Result = await queryResult.ToListQueryResultAsync(queryDataSource);

            return Result;
        }

        //public async Task<ListQueryResult<TeamEntity>> RemoveTeamFromChampionshipAsync(QueryDataSource<TeamEntity> queryDataSource)
        //{
        //    //var Result = new ListQueryResult<TeamEntity>
        //    //{
        //    //    Entities = new List<TeamEntity>()
        //    //};

        //    //var queryResult = from pt in GenericRepository.Query<TeamEntity>()
        //    //                  select pt;

        //    //Result = await queryResult.ToListQueryResultAsync(queryDataSource);

        //    //return Result;
        //}
    }
}
