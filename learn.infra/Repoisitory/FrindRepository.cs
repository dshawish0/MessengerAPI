using Dapper;
using learn.core.Data;
using learn.core.domain;
using Messenger.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Messenger.infra.Repoisitory
{
    public class FrindRepository : IFrindRepository
    {
        private readonly IDBContext dbContext;

        public FrindRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddFrind(Frinds frind)
        {
            var p = new DynamicParameters();
            p.Add("@crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Frind_Id", frind.Frindid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ReceiveId", frind.Userreceiveid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@FStatus", frind.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Add_Date", frind.Adddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@UserId", frind.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("FrindsCrud_Package.FrindsCrud", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteFrind(int userId, int reciveId)
        {
            var p = new DynamicParameters();
            p.Add("@crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ReceiveId", reciveId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("FrindsCrud_Package.FrindsCrud", p, commandType: CommandType.StoredProcedure);
        }

        public IList<Frinds> GetAllFrinds(int userId)
        {
            var p = new DynamicParameters();
            p.Add("@crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.Query<Frinds>("FrindsCrud_Package.FrindsCrud", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Frinds GetFrindById(int userId, int reciveId)
        {
            var p = new DynamicParameters();
            p.Add("@ReceiveId", reciveId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.Query<Frinds>("FrindsCrud_Package.getById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateFrind(Frinds frind)
        {
            var p = new DynamicParameters();
            p.Add("@crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Frind_Id", frind.Frindid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ReceiveId", frind.Userreceiveid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@FStatus", frind.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Add_Date", frind.Adddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@UserId", frind.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("FrindsCrud_Package.FrindsCrud", p, commandType: CommandType.StoredProcedure);
        }
    }
}
