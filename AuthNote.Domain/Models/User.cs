namespace AuthNote.Domain.Models
{
    public class User
    {
        private readonly List<Role> _roles = new List<Role>();

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

        public IReadOnlyCollection<Role> Roles => _roles;

        public Guid Id { get; }

        public static User Create(string username, string email, string identityId)
        {
            var user = new User(username, email, identityId, Guid.NewGuid());
            user._roles.Add(Role.User);

            return user;
        }

        public void AddNote(string title, string content) 
        {
            var note = Note.Create(title, content, this);

            Notes.Add(note);
        }

        public void AddRole(Role role)
        {
            _roles.Add(role);
        }
    }

}
