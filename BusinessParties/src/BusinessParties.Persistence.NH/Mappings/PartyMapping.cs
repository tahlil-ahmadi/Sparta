using System;
using System.Collections.Generic;
using System.Text;
using BusinessParties.Domain.Model;
using BusinessParties.Domain.Model.Parties;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace BusinessParties.Persistence.NH.Mappings
{
    public class PartyMapping : ClassMapping<Party>
    {
        public PartyMapping()
        {
            Table("Parties");
            Lazy(false);
            ComponentAsId(a=>a.Id, a =>
            {
                a.Property(z=>z.Id);
            });
            Property(a=>a.State, a=>a.Type<PartyStateMapping>());
            IdBag(a=>a.Phones, mapper =>
            {
                mapper.Table("Phones");
                mapper.Key(a=>a.Column("PartyId"));
                mapper.Cascade(Cascade.All);
                mapper.Access(Accessor.Field);
                mapper.Id(a =>
                {
                    a.Column("Id");
                    a.Generator(Generators.Identity);
                });
            }, relation=> relation.Component(mapper =>
            {
                mapper.Property(a=>a.Area);
                mapper.Property(a=>a.Number);
            }));
        }
    }
}
