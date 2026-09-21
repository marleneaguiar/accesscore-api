namespace Domain.Entities
{
    public class PersonalAccount
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; private set; }

        public DateTimeOffset CreatedAt { get; private set; }

        public PersonalAccount(string name, string email, string passwordHash, DateTimeOffset createdAt)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = createdAt;
        }

    }
}