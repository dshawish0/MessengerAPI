using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly IDBContext dbContext;

        public ServicesRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public T CrudServices<T>(Services services, string httpMethod)
        {
            var p = new DynamicParameters();
            p.Add("@crud", httpMethod, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@id", services.Serviceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SName", services.Servicename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PPrice", services.Preprice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("@SPrice", services.Saleprice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            

            switch (httpMethod)
            {
                case "G":
                    {
                        List<Services> result = dbContext.dbConnection.Query<Services>("ServicesCrud_Package.ServicesCrud", p, commandType: System.Data.CommandType.StoredProcedure).ToList();
                        return (T)Convert.ChangeType(result, typeof(T));
                    }
                //case "C":
                //    {
                //        var result = dbContext.dbConnection.ExecuteAsync("ServicesCrud_Package.ServicesCrud", p, commandType: CommandType.StoredProcedure);
                //        return (T)Convert.ChangeType(true, typeof(T));
                //    }
                //case "D":
                //    {
                //        dbContext.dbConnection.ExecuteAsync("ServicesCrud_Package.ServicesCrud", p, commandType: CommandType.StoredProcedure);
                //        return (T)Convert.ChangeType(true, typeof(T));
                //    }
                //case "U":
                //    {
                //        var result = dbContext.dbConnection.ExecuteAsync("ServicesCrud_Package.ServicesCrud", p, commandType: CommandType.StoredProcedure);
                //        return (T)Convert.ChangeType(true, typeof(T));
                //    }
                default:
                    {
                        var result = dbContext.dbConnection.ExecuteAsync("ServicesCrud_Package.ServicesCrud", p, commandType: CommandType.StoredProcedure);
                        return (T)Convert.ChangeType(true, typeof(T));
                    }
            }
            //return (T)Convert.ChangeType(value, typeof(T));
        }

        public Services GetServiceById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Services> result = dbContext.dbConnection.Query<Services>("ServicesCrud_Package.getById", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.FirstOrDefault();


        }
    }
}
