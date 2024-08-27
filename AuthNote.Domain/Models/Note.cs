namespace AuthNote.Domain.Models
{
    public class Note
    {
        private Note()
        {
        }

        protected Note(string title, string content, User user, Guid id)
        {
            Title = title;
            Content = content;
            User = user;
            Id = id;
        }

        public string Title { get; }

        public string Content { get; }

        public User User { get; }

        public Guid Id { get; }

        public static Note Create(string title, string content, User user)
        {
            return new Note(title, content, user, Guid.NewGuid());
        }
    }

}