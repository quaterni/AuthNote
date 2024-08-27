namespace AuthNote.Domain.Models
{
    public class User
    {
        private User()
        {
        }

        protected User(string firstName, string email, Guid id)
        {
            FirstName = firstName;
            Email = email;
            Id = id;
        }

        public string FirstName { get; } = null!;

        public string Email { get; } = null!;

        public ICollection<Note> Notes { get; } = new List<Note>();

        public Guid Id { get; }

        public static User Create(string firstName, string email)
        {
            return new User(firstName, email, Guid.NewGuid());
        }

        public void AddNote(string title, string content) 
        {
            var note = Note.Create(title, content, this);

            Notes.Add(note);
        }
    }

}
