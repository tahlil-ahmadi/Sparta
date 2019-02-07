using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using BusinessParties.Domain.Model.Parties.States;
using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace BusinessParties.Persistence.NH.Mappings
{
    public class PartyStateMapping : ImmutableUserType<PartyState>
    {
        public override object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            var value = (short)NHibernateUtil.Int16.NullSafeGet(rs, names[0], session);

            //TODO: use attribute to extract value of state
            if (value == 0)
                return new PendingState();
            else if (value == 1)
                return new ConfirmedState();
            else if (value == 99)
                return new RejectedState();
            else
                throw new NotImplementedException();
        }
        public override void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            var state = (PartyState)value;
            var numericValue = 255;

            //TODO: use attribute to extract value of state
            if (state is PendingState)
                numericValue = 0;
            else if (state is ConfirmedState)
                numericValue = 1;
            else if (state is RejectedState)
                numericValue = 99;
            else 
                throw new NotImplementedException();

            NHibernateUtil.String.NullSafeSet(cmd, numericValue.ToString(), index, session);
        }

        public override SqlType[] SqlTypes => new[] { new SqlType(DbType.Byte) };
    }
}
