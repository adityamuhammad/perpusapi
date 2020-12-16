using System.Collections.Generic;
using perpusapi.DataModel;

namespace perpusapi.Services 
{
    public interface IBookService 
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        void BorrowBook(BookMember bookMember);
        void ReturnBook(int borrowBookId);
    }
}