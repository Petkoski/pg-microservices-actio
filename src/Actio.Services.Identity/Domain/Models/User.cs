using Actio.Common.Exceptions;
using Actio.Services.Identity.Domain.Services;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Domain.Models
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("salt")]
        public string Salt { get; set; }
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        protected User()
        {

        }

        public User(string email, string name)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ActioException("empty_user_email", $"User email can not be empty.");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ActioException("empty_user_name", $"User name can not be empty.");
            }

            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ActioException("empty_password", $"Password can not be empty.");
            }

            Salt = encrypter.GetSalt();
            Password = encrypter.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
            => Password.Equals(encrypter.GetHash(password, Salt));
    }
}
