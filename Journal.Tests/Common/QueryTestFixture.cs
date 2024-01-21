using AutoMapper;
using Journal.Application.Common.Mappings;
using Journal.Application.Interfaces;
using Journal.Domain;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Journal.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public JournalDbContext context;
        public IMapper mapper;

        public QueryTestFixture()
        {
            context = JournalContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IJournalDbContext).Assembly));
            });
            mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            JournalContextFactory.Destroy(context);
        }

        [CollectionDefinition("QueryCollection")]
        public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
    }
}
