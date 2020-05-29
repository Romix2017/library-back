using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class BooksDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime PublishingDate { get; set; }
        public int GenresId { get; set; }
        public string Notation { get; set; }
    }
}
