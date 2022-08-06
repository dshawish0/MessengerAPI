using Dapper;
using learn.core.Data;
using learn.core.domain;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Messenger.infra.Repoisitory
{
    public class DtoRepository : IDtoRepository
    {
        private readonly IDBContext dbContext;

        public DtoRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public GetAllNumberOfFriends getAllNumberOfFriends(int userId)
        {
            GetAllNumberOfFriends getAllNumberOfFriends = new GetAllNumberOfFriends();
            var p = new DynamicParameters();
            p.Add("@crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.Query<Frinds>("FrindsCrud_Package.FrindsCrud", p, commandType: CommandType.StoredProcedure).ToList();
            getAllNumberOfFriends.frinds = result.Where(f=>f.Status==1).ToList();
            getAllNumberOfFriends.numOfFriends = result.Where(f=>f.Status==1).ToList().Count;
            return getAllNumberOfFriends;
        }
    }
}
