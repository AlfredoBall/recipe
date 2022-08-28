using System;
using System.Collections.Generic;
using HotChocolate.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;

namespace Recipe.API.GraphQL
{
        public class FilterCollectionTypeInterceptor : TypeInterceptor
    {
        private static bool IsCollectionType(Type t)
            => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>);

        public override void OnBeforeRegisterDependencies(ITypeDiscoveryContext discoveryContext, DefinitionBase? definition,
            IDictionary<string, object?> contextData)
        {
            if (definition is not ObjectTypeDefinition objectTypeDefinition) return;
            
            for (var i = 0; i < objectTypeDefinition.Fields.Count; i++)
            {
                var field = objectTypeDefinition.Fields[i];
                if (field.ResultType is null || !IsCollectionType(field.ResultType)) continue;
                
                var descriptor = field.ToDescriptor(discoveryContext.DescriptorContext)
                    .UsePaging()
                    // .UseFiltering()
                    // .UseSorting()
                    .UseProjection();
                objectTypeDefinition.Fields[i] = descriptor.ToDefinition();
            }
        }
    }
}