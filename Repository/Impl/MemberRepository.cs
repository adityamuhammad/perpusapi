using System.Collections.Generic;
using Dapper;
using perpusapi.DatabaseLib;
using perpusapi.DataModel;

namespace perpusapi.Repository.Impl 
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public MemberRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void AddMember(Member member)
        {
            _databaseConnection.connection.Execute("insert into Member(Name,Address,PhoneNumber) values(@Name,@Address,@PhoneNumber)", member);
        }

        public void DeleteMember(int id)
        {
            _databaseConnection.connection.Execute("delete from Member where Id = @Id", new { id });
        }

        public Member GetMember(int id)
        {
            var member = _databaseConnection.connection.QuerySingleOrDefault<Member>("select Id, Name, Address, PhoneNumber from Member where Id = @Id", new { id });
            return member;
        }

        public IEnumerable<Member> GetMembers()
        {
            var members = _databaseConnection.connection.Query<Member>("select top 10 Id, Name, Address, PhoneNumber from Member");
            return members;
        }

        public void UpdateMember(Member member)
        {
            _databaseConnection.connection.Execute("update Member set Name=@Name, Address=@Address, PhoneNumber=@PhoneNumber where Id = @Id", member);
        }
    }

}