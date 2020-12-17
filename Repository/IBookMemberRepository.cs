using System.Collections.Generic;
using perpusapi.DataModel;
using perpusapi.Dto;

namespace perpusapi.Repository
{
    public interface IBookMemberRepository
    {
        IEnumerable<BorrowingDto> GetBorrowingBooks();
        void AddBorrowBook(BookMember bookMember);
        void UpdateReturnDate(int borrowBookId);
    }
}