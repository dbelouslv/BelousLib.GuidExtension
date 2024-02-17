using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace BelousLib.GuidExtension
{
    /// <summary>
    ///     Set this filter only If you want to convert your 'Guidable' fields
    /// </summary>
    public class GuidableFilter : IResultFilter
    {
        /// <summary>
        ///     On Result Executed
        /// </summary>
        /// <param name="context">Context</param>
        public void OnResultExecuted(ResultExecutedContext context)
        {
            // If you don't want to modify the behavior, you can leave it like this
        }

        /// <summary>
        ///     On Result Executing
        /// </summary>
        /// <param name="context">Context</param>s
        public void OnResultExecuting(ResultExecutingContext? context)
        {
            if (context?.Result is not OkObjectResult okObjectResult) 
                return;

            foreach (var property in okObjectResult.Value.GetType().GetProperties())
            {
                if (!property.CanWrite || property.GetIndexParameters().Length != 0 ||
                    property.GetCustomAttribute<GuidableAttribute>() == null) 
                    continue;

                var value = property.GetValue(okObjectResult.Value);

                //Skip if values is null
                if (value is null)
                    continue;

                switch (property.PropertyType.Name)
                {
                    case "String":
                        property.SetValue(okObjectResult.Value, ((string)value).ToGuidFromString());
                        break;

                    case "Int16":
                        property.SetValue(okObjectResult.Value, ((short)value).ToGuid());
                        break;
                    
                    case "Int32":
                        property.SetValue(okObjectResult.Value, ((int)value).ToGuid());
                        break;
                    
                    case "Int64":
                        property.SetValue(okObjectResult.Value, ((long)value).ToGuid());
                        break;

                    case "UInt16":
                        property.SetValue(okObjectResult.Value, ((ushort)value).ToGuid());
                        break;

                    case "UInt32":
                        property.SetValue(okObjectResult.Value, ((uint)value).ToGuid());
                        break;

                    case "UInt64":
                        property.SetValue(okObjectResult.Value, ((ulong)value).ToGuid());
                        break;

                    case "Double":
                        property.SetValue(okObjectResult.Value, ((double)value).ToGuid());
                        break;

                    case "Single":
                        property.SetValue(okObjectResult.Value, ((float)value).ToGuid());
                        break;
                }
            }

            // Update the result with the modified model
            context.Result = new OkObjectResult(okObjectResult.Value);
        }
    }
}
