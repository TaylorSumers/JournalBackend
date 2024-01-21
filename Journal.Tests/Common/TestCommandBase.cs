using Journal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly JournalDbContext context;

        public TestCommandBase()
        {
            context = JournalContextFactory.Create();
        }

        public void Dispose()
        {
            JournalContextFactory.Destroy(context);
        }
    }
}
