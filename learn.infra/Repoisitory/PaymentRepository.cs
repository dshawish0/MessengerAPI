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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDBContext dbContext;

        public PaymentRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddPayments(Payments payment)
        {
            var p = new DynamicParameters();
            p.Add("@crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@id", payment.Paymentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@PDate", payment.Paymentdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@UserId", payment.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ServiceId", payment.ServiceId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("PaymentsCrud_Package.PaymentsCrud", p, commandType: CommandType.StoredProcedure);

        }

        public void DeletePayments(int id)
        {
            var p = new DynamicParameters();
            p.Add("@crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("PaymentsCrud_Package.PaymentsCrud", p, commandType: CommandType.StoredProcedure);
        }

        public IList<Payments> GetAllPayments()
        {
            var p = new DynamicParameters();
            p.Add("@crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Payments> result = dbContext.dbConnection.Query<Payments>("PaymentsCrud_Package.PaymentsCrud", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public Payments GetPaymentsById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Payments> result = dbContext.dbConnection.Query<Payments>("PaymentsCrud_Package.getById", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpDatePayments(Payments payment)
        {
            var p = new DynamicParameters();
            p.Add("@crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@id", payment.Paymentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@PDate", payment.Paymentdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@UserId", payment.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ServiceId", payment.ServiceId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("PaymentsCrud_Package.PaymentsCrud", p, commandType: CommandType.StoredProcedure);
        }
    }
}
