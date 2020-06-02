using Microsoft.Extensions.DependencyInjection;

using System;

using TinyCrm.Core;

namespace TinyCrm.Tests
{
    public class TinyCrmFixture : IDisposable
    {
        private IServiceScope scope_;

        public IServiceProvider Provider { get; private set; }
        public TinyCrmFixture()
        {
            IServiceCollection sc = new ServiceCollection();
            sc.AddTinyCrmServices();

            scope_ = sc.BuildServiceProvider().CreateScope();
            Provider = scope_.ServiceProvider;
        }

        public void Dispose()
        {
            scope_.Dispose();
        }
    }
}
