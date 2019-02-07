using System;
using System.Collections.Generic;
using BusinessParties.Domain.Model;
using BusinessParties.Domain.Model.Parties;
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
           
            var party = session.Get<IndividualParty>(new PartyId(1));
        }
    }
}
