using System;
using System.Collections.Generic;
using Dapper;
using perpusapi.DatabaseLib;
using perpusapi.DataModel;
using perpusapi.Dto;

namespace perpusapi.Repository.Impl
{
    public class BookMemberRepository : IBookMemberRepository
    {
        private readonly DatabaseConnection _databaseConnection;
        public BookMemberRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public IEnumerable<BorrowingDto> GetBorrowingBooks()
        {
            return _databaseConnection.connection.Query<BorrowingDto>(@"
                select Top 10 
                    bb.Id as Id, b.Title as Title, 
                    b.Author as Author, m.Name as BorrowerName,
                    m.Address as BorrowerAddress, m.PhoneNumber as BorrowerPhoneNumber,
                    bb.BorrowDate as BorrowDate, bb.ReturnDate as ReturnDate
                from BorrowBook bb
                inner join Book b on bb.BookId = b.Id
                inner join Member m on bb.MemberId = m.Id
                "
            );

        }

        public void AddBorrowBook(BookMember bookMember)
        {
            _databaseConnection.connection.Execute(@"
                insert into BorrowBook(BookId, MemberId, BorrowDate) 
                values (@BookId, @MemberId, @BorrowDate)", 
            bookMember);
        }

        public void UpdateReturnDate(int borrowBookId)
        {
            _databaseConnection.connection.Execute(@"
                update BorrowBook 
                set ReturnDate=@ReturnDate 
                where Id = @Id", 
                new {Id = borrowBookId, ReturnDate=DateTime.Now});
        }
    }
}