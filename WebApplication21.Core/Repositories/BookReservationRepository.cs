using Microsoft.EntityFrameworkCore;
using WebApplication21.Core.Data;
using WebApplication21.Core.Entities;
using WebApplication21.Core.Interfaces;

namespace WebApplication21.Core.Repositories
{
    public class BookReservationRepository : EntityRepository<BookReservation>, 
        IBookReservationRepository
    {
        private readonly WebApplication21DbContext _context;
        public BookReservationRepository(WebApplication21DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookReservation>> GetAllReservationFromOneBook(int bookId)
        {
            return await _context.BooksReservation.Where(x => x.BookId == bookId).ToListAsync();
        }

    }
}
