using WebApplication21.Core.Entities;

namespace WebApplication21.Core.Interfaces
{
    public interface IBookReservationRepository : IEntityRepository<BookReservation>
    {
        Task<IEnumerable<BookReservation>> GetAllReservationFromOneBook(int bookId);
    }
}
