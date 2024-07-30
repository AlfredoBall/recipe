using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Recipe.Data;
using System.Collections;
using System;
using System.Reflection;
using HotChocolate.Execution;
using System.Data.SqlClient;

namespace Recipe.API
{
    public class DbContextFactory : Microsoft.EntityFrameworkCore.IDbContextFactory<Recipe.Data.Context>
    {
        private IHttpContextAccessor _httpContextAccessor;

        public DbContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Context CreateDbContext()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            var tenantInfo = httpContext.GetMultiTenantContext<TenantInfo>().TenantInfo;

            var options = new DbContextOptionsBuilder<Recipe.Data.Context>().UseSqlServer(tenantInfo?.ConnectionString);
            var context = new Recipe.Data.Context(options);

            return context;
        }
    }
}
