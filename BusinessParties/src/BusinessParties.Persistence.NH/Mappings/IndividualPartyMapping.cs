using System;
using System.Collections.Generic;
using System.Text;
using BusinessParties.Domain.Model;
using BusinessParties.Domain.Model.Parties;
using NHibernate.Mapping.ByCode.Conformist;

namespace BusinessParties.Persistence.NH.Mappings
{
    public class IndividualPartyMapping : JoinedSubclassMapping<IndividualParty>
    {
        public IndividualPartyMapping()
        {
            Table("IndividualParties");
            Lazy(false);
            Key(a=>a.Column("Id"));
            Property(a=>a.Firstname);
            Property(a=>a.Lastname);
        }
    }
}
