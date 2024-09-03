using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthNote.LocalIdentity
{
    public class Identity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
