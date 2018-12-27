using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityAccess.Domain.Model.Users
{
    public class User
    {
        private List<UserClaim> _claims;
        public int Id { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public IReadOnlyList<UserClaim> Claims => _claims.AsReadOnly();
        public User(int id, string username, int roleId)
        {
            Id = id;
            Username = username;
            RoleId = roleId;

            this._claims = new List<UserClaim>();
        }

        public void AddClaim(string key, string value)
        {
            this._claims.Add(new UserClaim(key,value));
        }
    }
}
