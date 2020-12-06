using System;
using Dapper;
using perpusapi.DatabaseLib;

namespace perpusapi.Repository.Impl
{
    public class BookMemberRepository : IBookMemberRepository
    {
        private readonly DatabaseConnection _databaseConnection;
        public BookMemberRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
            
        }
        public void AddBorrowBook(int bookId, int memberId)
        {
            _databaseConnection.dbConnection.Execute("insert into BorrowBook(BookId, MemberId, BorrowDate) values (@BookId, @MemberId, @BorrowDate)", new {BookId = bookId, MemberId = memberId, BorrowDate= DateTime.Now});
        }

        public void UpdateReturnDate(int borrowBookId)
        {
            _databaseConnection.dbConnection.Execute("update BorrowBook set ReturnDate=@ReturnDate where Id = @Id", new {Id = borrowBookId, ReturnDate=DateTime.Now});
        }
    }
}