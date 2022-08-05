using Dapper;
using learn.core.domain;
using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Messenger.infra.Repoisitory
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDBContext dBContext;

        public LoginRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<Login> GetAllLog()
        {
            throw new NotImplementedException();
        }

        public bool InsertLog(UserLogDTO userLog)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@EEmail", userLog.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@PPassword", userLog.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
                ("@UUser_Id", userLog.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("@RRoleId", 2, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("UserrCRUD_Package.UserrCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool UpdateLog(Login userLog)
        {
            throw new NotImplementedException();
        }
    }
}
