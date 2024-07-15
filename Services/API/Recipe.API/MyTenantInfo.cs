using Finbuckle.MultiTenant;

namespace Recipe.API
{
    public class MyTenantInfo : TenantInfo
    {
        public MyTenantInfo() { }
        public string? Database { get; set; }
    }
}
