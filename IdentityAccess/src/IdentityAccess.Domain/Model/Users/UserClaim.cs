using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityAccess.Domain.Model.Users
{
    public class UserClaim  //TODO: put 'valueObject' here
    {
        public string Key { get;  private set; }
        public string Value { get;private set; }
        public UserClaim(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
