namespace perpusapi.Repository
{
    public interface IBookMemberRepository
    {
        void AddBorrowBook(int bookId, int memberId);
        void UpdateReturnDate(int borrowBookId);
    }
}