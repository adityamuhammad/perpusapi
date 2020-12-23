using System.Collections.Generic;
using perpusapi.DataModel;
using perpusapi.Dto;
using perpusapi.ParamFilter;

namespace perpusapi.Services 
{
    public interface IBookService 
    {
        IEnumerable<Book> GetBooks(Filter filter);
        Book GetBook(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        IEnumerable<BorrowingDto> GetBorrowingBooks(Filter filter);
        void BorrowBook(BookMember bookMember);
        void ReturnBook(int borrowBookId);
    }
}