using System.Collections.Generic;
using Dapper;
using perpusapi.DatabaseLib;
using perpusapi.DataModel;
using perpusapi.ParamFilter;

namespace perpusapi.Repository.Impl 
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public BookRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public IEnumerable<Book> GetBooks(Filter filter)
        {
            var filtering = string.Empty;
            if (!string.IsNullOrEmpty(filter.Search))
            {
                filtering += " where Title like concat(@Search, '%') or Author like concat(@search, '%') ";
            }
            var books = _databaseConnection.connection.Query<Book>($@"
                select 
                    Id, Title, Author, 
                    PublishedDate, CreatedDate 
                from Book 
                {filtering}
                order by id desc
                offset ((@Page-1) * @NumOfRows) rows fetch first @NumOfRows rows only
                ", filter);
            return books;
        }

        public Book GetBook(int id)
        {
            var book = _databaseConnection.connection.QuerySingleOrDefault<Book>(@"
                select 
                    Id, Title, Author, 
                    PublishedDate, CreatedDate 
                from Book where Id = @Id", new { id });
            return book;
        }

        public void AddBook(Book book)
        {
            _databaseConnection.connection.Execute(@"
                insert into Book(Title,Author,PublishedDate) 
                values(@Title,@Author,@PublishedDate)", 
            book);
        }

        public void DeleteBook(int id)
        {
            _databaseConnection.connection.Execute(@"
                delete from Book where Id=@Id", 
            new { id });
        }
        public void UpdateBook(Book book)
        {
            _databaseConnection.connection.Execute(@"
                update Book 
                    set Title=@Title, 
                    Author=@Author 
                where Id=@Id", 
            book);
        }

    }

}