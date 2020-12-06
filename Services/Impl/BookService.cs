using System.Collections.Generic;
using perpusapi.DataModel;
using perpusapi.Repository;

namespace perpusapi.Services.Impl {
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

        public void BorrowBook(int bookId, int memberId)
        {
            _bookMemberRepository.AddBorrowBook(bookId,memberId);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        public Book GetBook(int id)
        {
            return _bookRepository.GetBook(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
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