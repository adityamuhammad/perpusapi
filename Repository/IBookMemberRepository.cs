using System.Collections.Generic;
using perpusapi.DataModel;
using perpusapi.Dto;
using perpusapi.ParamFilter;

namespace perpusapi.Repository
{
    public interface IBookMemberRepository
    {
        IEnumerable<BorrowingDto> GetBorrowingBooks(Filter filter);
        void AddBorrowBook(BookMember bookMember);
        void UpdateReturnDate(int borrowBookId);
    }
}