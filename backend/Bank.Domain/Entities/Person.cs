namespace Bank.Domain.Entities
{
    public class Person
    {
        public int PersonId { get; set; }

        public string DocumentNumber { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public int GenderId { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Phone { get; set; } = string.Empty;
    }
}