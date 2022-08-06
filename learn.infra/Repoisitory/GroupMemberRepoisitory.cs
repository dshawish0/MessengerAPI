using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using learn.infra.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class GroupMemberRepoisitory : IGroupMemberRepoisitory
    {
        private readonly IDBContext dBContext;

        public GroupMemberRepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public bool DeleteGroupMember(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "D", dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("GGroupMemberId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("GroupMemberCRUD_Package.GroupMemberCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
                return false;
            return true;
        }

        public List<GroupMember> GetGroupMember()
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<GroupMember> result = dBContext.dbConnection.Query<GroupMember>("GroupMemberCRUD_Package.GroupMemberCRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<GroupMember> GetGroupMemberById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("GGroupMemberId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GroupMember> result = dBContext.dbConnection.Query<GroupMember>("GroupMemberCRUD_Package.getById", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool InsertGroupMember(GroupMember groupMember)
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("JJoinDate", groupMember.JoinDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("LLeftDate", groupMember.LeftDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("MMessageGroupId", groupMember.MessageGroupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("UUser_Id", groupMember.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("GroupMemberCRUD_Package.GroupMemberCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool UpdateGroupMember(GroupMember groupMember)
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("GGroupMemberId", groupMember.GroupMemberId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("JJoinDate", groupMember.JoinDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("LLeftDate", groupMember.LeftDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("MMessageGroupId", groupMember.MessageGroupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("UUser_Id", groupMember.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.ExecuteAsync("GroupMemberCRUD_Package.GroupMemberCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
