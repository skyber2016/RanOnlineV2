using Dapper;
using Dapper.FastCrud;
using Framework;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.RankingModel
{
    public class GetRankingAction : CommandBase<IEnumerable<dynamic>>
    {
        private IEnumerable<ChaInfo> GetChaInfos(ObjectContext context)
        {
            var query = new StringBuilder();
            query.Append("select top 5 ChaInfo.ChaLevel, ChaInfo.ChaKills,ChaInfo.ChaName,ChaInfo.ChaDefenseP  from ChaInfo");
            query.Append(" order by ChaInfo.ChaLevel DESC, ChaInfo.ChaKills DESC, ChaInfo.ChaDefenseP ASC");
            return context.RanGame.Query<ChaInfo>(query.ToString());
        }
        protected override Result<IEnumerable<dynamic>> ExecuteCore(ObjectContext context)
        {
            var rank = 1;
            var result = this.GetChaInfos(context);
            return Success(result.Select(x=> {
                return new
                {
                    name = x.ChaName,
                    rank = rank++,
                    level = x.ChaLevel,
                    kill = x.ChaKills,
                    death = x.ChaDefenseP
                };
            }));
        }
    }
}
