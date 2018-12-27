using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityAccess.Domain.Model.UserGroups
{
    public class UserGroupPermission    //TODO: value object
    {
        public string Permission { get; set; }
        public GrantType GrantType { get; set; }
        public UserGroupPermission(string permission, GrantType grantType)
        {
            Permission = permission;
            GrantType = grantType;
        }
    }
}
