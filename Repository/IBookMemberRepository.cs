using perpusapi.DataModel;

namespace perpusapi.Repository
{
    public interface IBookMemberRepository
    {
        void AddBorrowBook(BookMember bookMember);
        void UpdateReturnDate(int borrowBookId);
    }
}