using System.Collections;
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

            if (okObjectResult.Value is IList items)
            {
                var resultList = (from object item in items select HandleItem(item)).ToList();

                context.Result = new OkObjectResult(resultList);

                return;
            }

            context.Result = new OkObjectResult(HandleItem(okObjectResult.Value));
        }

        private static Dictionary<string, dynamic?> HandleItem(object item)
        {
            var items = new Dictionary<string, dynamic?>();

            foreach (var property in item.GetType().GetProperties())
            {
                var value = property.GetValue(item);

                if (!property.CanWrite || property.GetIndexParameters().Length != 0 || property.GetCustomAttribute<GuidableAttribute>() == null)
                {
                    items.Add(property.Name, value);
                    continue;
                }

                var enableZeroRemoving = property.GetCustomAttribute<GuidableAttribute>()?.EnableZeroRemoving ?? true;

                //Skip if values is null
                if (value is null)
                {
                    items.Add(property.Name, value);
                    continue;
                }

                switch (property.PropertyType.Name)
                {
                    case "String":
                        items.Add(property.Name, ((string)value).ToGuidFromString());
                        break;

                    case "Int16":
                        items.Add(property.Name, ((short)value).ToGuid(enableZeroRemoving));
                        break;

                    case "Int32":
                        items.Add(property.Name, ((int)value).ToGuid(enableZeroRemoving));
                        break;

                    case "Int64":
                        items.Add(property.Name, ((long)value).ToGuid(enableZeroRemoving));
                        break;

                    case "UInt16":
                        items.Add(property.Name, ((ushort)value).ToGuid(enableZeroRemoving));
                        break;

                    case "UInt32":
                        items.Add(property.Name, ((uint)value).ToGuid(enableZeroRemoving));
                        break;

                    case "UInt64":
                        items.Add(property.Name, ((ulong)value).ToGuid(enableZeroRemoving));
                        break;

                    case "Double":
                        items.Add(property.Name, ((double)value).ToGuid(enableZeroRemoving));
                        break;

                    case "Single":
                        items.Add(property.Name, ((float)value).ToGuid(enableZeroRemoving));
                        break;
                }
            }

            return items;
        }
    }
}
