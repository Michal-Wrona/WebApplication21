namespace WebApplication21.Core.Entities
{
    public class BookReservation : BaseEntity
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime DateReservation { get; set; } = DateTime.Now;
    }
}
