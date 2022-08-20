using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.infra.Repoisitory
{
    public class MessageGroupRepoisitory : IMessageGroupRepoisitory
    {
        private readonly IDBContext dBContext;
        public MessageGroupRepoisitory(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public string CreateMessageGroup(MessageGroup ins)
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud","C", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("GGroupName", ins.GroupName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("GGroupImg", ins.GroupImg, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync("MessageGroupCRUD_Package.MessageGroupCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
            {

                return "NotInserted";
            }
            else
            {
                return "Inserted";
            }
        }

        public string DeleteMessageGroup(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud ", "D", dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("MMessageGroupId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.dbConnection.Execute("MessageGroupCRUD_Package.MessageGroupCRUD", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return "Notdelete";
            }
            else
            {
                return "deleted";
            }
        }

        public List<MessageGroup> GetAllMessageGroup()
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "G", dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<MessageGroup> result = dBContext.dbConnection.Query<MessageGroup>("MessageGroupCRUD_Package.MessageGroupCRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IList<MessageGroup>> GetFullMessageGroup(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await dBContext.dbConnection.QueryAsync<MessageGroup, Message, GroupMember, Userr, MessageGroup>("Chat_Package.Chat", (messageGroup, message, groupMember,  user) =>
            {
                messageGroup.Messages = messageGroup.Messages ?? new List<Message>();
                messageGroup.Messages.Add(message);
                messageGroup.GroupMembers = messageGroup.GroupMembers ?? new List<GroupMember>();
                messageGroup.GroupMembers.Add(groupMember);
                

                messageGroup.GroupMembers.First().User = messageGroup.GroupMembers.First().User ?? new Userr();
                messageGroup.GroupMembers.First().User = user;


                return messageGroup;
            },
            splitOn: "MessageGroupId,MessageId,GroupMemberId,userId",
            param: parameter,
            commandType: CommandType.StoredProcedure
            );

            var value = result.AsList<MessageGroup>().OrderBy(x => x.MessageGroupId).Distinct()
                .GroupBy(x => x.MessageGroupId)
                .Select(o =>
                {
                    MessageGroup messageGroup = o.First();
                    messageGroup.Messages = o.Distinct().Select(m => m.Messages.Single()).Select(message => new Message
                    {
                        MessageId = message.MessageId,
                        Text = message.Text,
                        MessageDate = message.MessageDate,
                        SenderId = message.SenderId,
                        MessageGroupId = message.MessageGroupId
                    }).Distinct().ToList();
                    messageGroup.GroupMembers = o.Distinct().Select(t => t.GroupMembers.Single()).Select(groupMember => new GroupMember
                    {
                        MessageGroupId = groupMember.MessageGroupId,
                        GroupMemberId = groupMember.GroupMemberId,
                        JoinDate = groupMember.JoinDate,
                        LeftDate = groupMember.LeftDate,
                        User_Id = groupMember.User_Id,
                        User = groupMember.User
                    }).Distinct().ToList();
                    //messageGroup.GroupMembers.First().User = o.Select(t => t.GroupMembers.Single()).Select(user => new Userr
                    //{
                    //  UserId = user.User.UserId,
                    //  Fname = user.User.Fname,
                    //  Lname = user.User.Lname,
                    //  userName = user.User.userName,
                    //  ProFileImg = user.User.ProFileImg,
                    //  IsActive = user.User.IsActive,
                    //  IsBlocked = user.User.IsBlocked,
                    //  Gender = user.User.Gender,
                    //  UserBio = user.User.UserBio
                    //}).First();

                    return messageGroup;
                }).ToList();

            return value.ToList();





        }

        public MessageGroup GetMessageGroupById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("MMessageGroupId ", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<MessageGroup> result = dBContext.dbConnection.Query<MessageGroup>("MessageGroupCRUD_Package.getById", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public string UpDateMessageGroup(MessageGroup upd)
        {
            var parameter = new DynamicParameters();
            parameter.Add("crud", "U", dbType: DbType.String, direction: ParameterDirection.Input);

            parameter.Add("MMessageGroupId", upd.MessageGroupId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("GGroupName", upd.GroupName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("GGroupImg", upd.GroupImg, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.dbConnection.ExecuteAsync("MessageGroupCRUD_Package.MessageGroupCRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result == null)
            {

                return "NotUpDate";
            }
            else
            {
                return "UpDate";
            }
        }
    }
}
