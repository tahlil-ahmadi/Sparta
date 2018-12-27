using System.Collections.Generic;
using IdentityAccess.Domain.Model.Users;

namespace IdentityAccess.Domain.Model.UserGroups
{
    public class UserGroup
    {
        private List<int> _userIds;
        private List<UserGroupPermission> _permissions;
        public int Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyList<int> UserIds => _userIds.AsReadOnly();
        public IReadOnlyList<UserGroupPermission> Permissions => _permissions.AsReadOnly();
        public UserGroup(int id, string name)
        {
            Id = id;
            Name = name;
            this._userIds = new List<int>();
        }

        public void AddUser(User user)
        {
            this._userIds.Add(user.Id);
        }

        public void AddPermissions(List<UserGroupPermission> permissions)
        {
            //TODO: use 'UpdateValueObject' method
            this._permissions = permissions;
        }
    }
}
