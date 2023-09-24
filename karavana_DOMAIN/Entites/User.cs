using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_DOMAIN.Entites
{
    public sealed class User : IdentityUser
    {
        public User(string? firstName, string? lastName, string? address, string? profilePictureUrl, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ProfilePictureUrl = profilePictureUrl;
            Email = email;

            ChangedAt = null;
            ChangedBy = null;
        }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Address { get; private set; }
        public string? ProfilePictureUrl { get; private set; }
        // Audit
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public string CreatedBy { get; private set; } = string.Empty;
        public DateTime? ChangedAt { get; private set; }
        public string? ChangedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;

    }
}
