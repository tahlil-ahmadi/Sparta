using System;
using System.Collections.Generic;
using BusinessParties.Domain.Model;
using BusinessParties.Persistence.NH.Mappings;
using Xunit;

namespace BusinessParties.Persistence.NH.Tests.Integration
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var connectionString = @"Data Source=CLASS1\MSSQLSERVER1;Initial Catalog=PartyManagementDB;User Id=sa;Password=123";
            var sessionFactory = SessionFactoryBuilder.Create(typeof(PartyMapping).Assembly, connectionString);
            var session = sessionFactory.OpenSession();

            session.BeginTransaction();
            var phones = new List<Phone>()
            {
                new Phone("021", "11"),
                new Phone("021", "44"),
            };
            var party = session.Get<IndividualParty>(new PartyId(1));
            party.AssignPhones(phones);
            session.Save(party);
            session.Transaction.Commit();
        }
    }
}
