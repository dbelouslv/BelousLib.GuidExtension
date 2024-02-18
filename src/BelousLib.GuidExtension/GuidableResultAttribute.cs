using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace BelousLib.GuidExtension
{
    /// <summary>
    ///     Set this filter only If you want to convert your 'Guidable' fields
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class GuidableResultAttribute : Attribute, IResultFilter
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
            {
                return;
            }

            var newResult = new Dictionary<string, dynamic?>();

            foreach (var property in okObjectResult.Value.GetType().GetProperties())
            {
                var value = property.GetValue(okObjectResult.Value);

                if (!property.CanWrite || property.GetIndexParameters().Length != 0 || property.GetCustomAttribute<GuidableAttribute>() == null)
                {
                    newResult.Add(property.Name, value);
                    continue;
                }

                var enableZeroRemoving = property.GetCustomAttribute<GuidableAttribute>()?.EnableZeroRemoving ?? true;

                //Skip if values is null
                if (value is null)
                {
                    newResult.Add(property.Name, value);
                    continue;
                }

                switch (property.PropertyType.Name)
                {
                    case "String":
                        newResult.Add(property.Name, ((string)value).ToGuidFromString());
                        break;

                    case "Int16":
                        newResult.Add(property.Name, ((short)value).ToGuid(enableZeroRemoving));
                        break;

                    case "Int32":
                        newResult.Add(property.Name, ((int)value).ToGuid(enableZeroRemoving));
                        break;

                    case "Int64":
                        newResult.Add(property.Name, ((long)value).ToGuid(enableZeroRemoving));
                        break;

                    case "UInt16":
                        newResult.Add(property.Name, ((ushort)value).ToGuid(enableZeroRemoving));
                        break;

                    case "UInt32":
                        newResult.Add(property.Name, ((uint)value).ToGuid(enableZeroRemoving));
                        break;

                    case "UInt64":
                        newResult.Add(property.Name, ((ulong)value).ToGuid(enableZeroRemoving));
                        break;

                    case "Double":
                        newResult.Add(property.Name, ((double)value).ToGuid(enableZeroRemoving));
                        break;

                    case "Single":
                        newResult.Add(property.Name, ((float)value).ToGuid(enableZeroRemoving));
                        break;
                }
            }

            // Update the result with the modified model
            context.Result = new OkObjectResult(newResult);
        }
    }
}
