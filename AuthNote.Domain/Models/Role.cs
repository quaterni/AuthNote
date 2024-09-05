using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthNote.Domain.Models
{
    public sealed class Role
    {
        public static readonly Role Admin = new(1, "Admin");
        public static readonly Role User = new(2, "User");

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; init; }

        public string Name { get; init; }

        public ICollection<User> Users { get; init; } = new List<User>();
    }
}
