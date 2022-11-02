namespace WebApplication21.Core.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PasswordHash { get; set; }
        //public List<BookReservation> BookReservations { get; set; }
    }
}
