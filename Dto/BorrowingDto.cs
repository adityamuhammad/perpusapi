using System;

namespace perpusapi.Dto
{
    public class BorrowingDto 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string BorrowerName { get; set; }
        public string BorrowerAddress { get; set; }
        public string BorrowerPhoneNumber { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate {get; set; }
    }
}