using System.Collections.Generic;
using perpusapi.DataModel;
using perpusapi.ParamFilter;

namespace perpusapi.Repository
{
    public interface IBookRepository 
    {
        IEnumerable<Book> GetBooks(Filter filter);
        Book GetBook(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }

}