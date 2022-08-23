using Dapper;
using learn.core.domain;
using Messenger.core.Data;
using Messenger.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Messenger.infra.Repoisitory
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDBContext dBContext;

        public TestimonialRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public bool DeleteTest(int testId)
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "D", dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("@UUserId", testId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync
                ("testimonialCRUD_Package.testimonialCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<testimonial> GetAllTests()
        {
            var parameter = new DynamicParameters();
            parameter.Add
                ("@crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<testimonial> result = dBContext.dbConnection.Query<testimonial>
                ("testimonialCRUD_Package.testimonialCRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public testimonial GetTestById(int testId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@TTestId", testId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<testimonial> result = dBContext.dbConnection.Query<testimonial>
                ("testimonialCRUD_Package.getById", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool InsertTest(testimonial test)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@MMessage", test.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@Sstatus", test.status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("@PpublishDate", test.publishDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameter.Add
               ("@UuserId", test.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dBContext.dbConnection.ExecuteAsync
              ("testimonialCRUD_Package.testimonialCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public bool UpdateTest(testimonial test)
        {
            var parameter = new DynamicParameters();
            parameter.Add
               ("@crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
              ("@TTestId", test.TestId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
               ("@MMessage", test.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add
               ("@Sstatus", test.status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add
                ("@PpublishDate", test.publishDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameter.Add
               ("@UuserId", test.userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync
                ("testimonialCRUD_Package.testimonialCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }
    }
}
