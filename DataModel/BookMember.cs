using System;

namespace perpusapi.DataModel
{
    public class BookMember 
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime BorrowDate {get; set;}
        public DateTime? ReturnDate {get; set;}
    }
}