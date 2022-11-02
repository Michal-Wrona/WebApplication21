using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication21.Core.Entities
{
    public class BookReservation : BaseEntity
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        //public Book Book { get; set; }
        //public User User { get; set; }

        //public List<Book> Books { get; set; }
        //public List<User> Users { get; set; }
    }
}
