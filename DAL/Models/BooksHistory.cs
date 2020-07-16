using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class BooksHistory
    {
        public int Id { get; set; }
        public int BooksId { get; set; }
        public Books Books { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
        public DateTime? DateGiven { get; set; }
        public DateTime? DateReturned { get; set; }
        public string Notes { get; set; }
    }
}
