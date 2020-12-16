using System;
using Dapper;
using perpusapi.DatabaseLib;
using perpusapi.DataModel;

namespace perpusapi.Repository.Impl
{
    public class BookMemberRepository : IBookMemberRepository
    {
        private readonly DatabaseConnection _databaseConnection;
        public BookMemberRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
            
        }
        public void AddBorrowBook(BookMember bookMember)
        {
            _databaseConnection.connection.Execute("insert into BorrowBook(BookId, MemberId, BorrowDate) values (@BookId, @MemberId, @BorrowDate)", bookMember);
        }

        public void UpdateReturnDate(int borrowBookId)
        {
            _databaseConnection.connection.Execute("update BorrowBook set ReturnDate=@ReturnDate where Id = @Id", new {Id = borrowBookId, ReturnDate=DateTime.Now});
        }
    }
}