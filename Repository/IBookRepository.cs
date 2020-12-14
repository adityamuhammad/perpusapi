using System.Collections.Generic;
using perpusapi.DataModel;

namespace perpusapi.Repository
{
    public interface IBookRepository 
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }

}