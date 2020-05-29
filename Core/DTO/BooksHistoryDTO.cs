using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class BooksHistoryDTO
    {
        public int Id { get; set; }
        public int BooksId { get; set; }
        public int UsersId { get; set; }
        public DateTime DateGiven { get; set; }
        public DateTime DateReturned { get; set; }
        public string Notes { get; set; }
    }
}
