using System.Collections.Generic;
using perpusapi.DataModel;
using perpusapi.Repository;
using perpusapi.Dto;
using perpusapi.ParamFilter;

namespace perpusapi.Services.Impl 
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookMemberRepository _bookMemberRepository;

        public BookService(IBookRepository bookRepository, IBookMemberRepository bookMemberRepository)
        {
            _bookRepository = bookRepository;
            _bookMemberRepository = bookMemberRepository;
        }

        public void AddBook(Book book)
        {
            _bookRepository.AddBook(book);
        }

        public void BorrowBook(BookMember bookMember)
        {
            _bookMemberRepository.AddBorrowBook(bookMember);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        public Book GetBook(int id)
        {
            return _bookRepository.GetBook(id);
        }

        public IEnumerable<Book> GetBooks(Filter filter)
        {
            return _bookRepository.GetBooks(filter);
        }

        public IEnumerable<BorrowingDto> GetBorrowingBooks()
        {
            return _bookMemberRepository.GetBorrowingBooks();
        }

        public void ReturnBook(int borrowBookId)
        {
            _bookMemberRepository.UpdateReturnDate(borrowBookId);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }
    }
}