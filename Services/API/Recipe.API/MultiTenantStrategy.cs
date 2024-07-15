using Finbuckle.MultiTenant;
using HotChocolate.AspNetCore.Serialization;
using HotChocolate.Execution;
using HotChocolate.Language;
using Microsoft.AspNetCore.Http;

namespace Recipe.API
{
    public class MultiTenantStrategy : IMultiTenantStrategy
    {
        private string? _identifier;

        public Task<string?> GetIdentifierAsync(object context)
        {
            return Task.FromResult<string?>(_identifier);
        }

        public MultiTenantStrategy(IHttpRequestParser parser, IHttpContextAccessor contextAccessor, IRequestContextAccessor requestContextAccessor)
        {
            try
            {
                var mem = new MemoryStream();

                contextAccessor.HttpContext.Request.Body.CopyToAsync(mem);

                mem.Seek(0, SeekOrigin.Begin);

                var request = parser.ReadJsonRequestAsync(mem, CancellationToken.None).Result;

                mem.Seek(0, SeekOrigin.Begin);

                contextAccessor.HttpContext.Request.Body = mem;

                var operationDefinition = request[0].Query.Definitions[0] as OperationDefinitionNode;

                var fieldNode = operationDefinition.SelectionSet.Selections[0] as FieldNode;

                var argumentNode = fieldNode.Arguments.Where(arg => arg.Name.Value == "database").Single();

                _identifier = argumentNode.Value.Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
