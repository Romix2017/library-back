using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime? PublishingDate { get; set; }
        public Genres Genres { get; set; }
        public int GenresId { get; set; }
        public string Notation { get; set; }
    }
}
