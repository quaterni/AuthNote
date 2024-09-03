namespace AuthNote.Domain.Models
{
    public class User
    {
        private User()
        {
        }

        protected User(string Username, string email, string identityId, Guid id)
        {
            this.Username = Username;
            Email = email;
            IdentityId = identityId;
            Id = id;
        }

        public string Username { get; } = null!;

        public string Email { get; } = null!;

        public string IdentityId { get; }
        public ICollection<Note> Notes { get; } = new List<Note>();

        public Guid Id { get; }

        public static User Create(string username, string email, string identityId)
        {
            return new User(username, email, identityId, Guid.NewGuid());
        }

        public void AddNote(string title, string content) 
        {
            var note = Note.Create(title, content, this);

            Notes.Add(note);
        }
    }

}
