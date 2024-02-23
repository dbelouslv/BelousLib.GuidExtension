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
                if (property.PropertyType != typeof(string) && property.PropertyType.IsClass)
                {
                    items.Add(property.Name, HandleItem(property.GetType().GetProperties()));
                }
                else if (property.PropertyType != typeof(string) && IsList(property))
                {
                    var elementType = property.PropertyType.GetGenericArguments().First();

                    if (elementType != typeof(string) && elementType.IsClass)
                    {
                        items.Add(property.Name, GetObjectValues(item, property));
                    }
                    else
                    {
                        items.Add(property.Name, GetValues(item, property));
                    }
                }
                else
                {
                    items.Add(property.Name, GetValue(item, property));
                }
            }

            return items;
        }

        private static List<dynamic?> GetObjectValues(object item, PropertyInfo property)
        {
            return ((IEnumerable)property.GetValue(item)).Cast<object>().Select(subItem => HandleItem(subItem)).Cast<dynamic?>().ToList();
        }

        private static List<dynamic?> GetValues(object item, PropertyInfo property)
        {
            var values = new List<dynamic?>();

            if (property.GetCustomAttribute<GuidableAttribute>() is not null)
            {
                var enableZeroRemoving = property.GetCustomAttribute<GuidableAttribute>()?.EnableZeroRemoving ?? true;

                values.AddRange(((IEnumerable)property.GetValue(item)).Cast<dynamic>().Select(subItem => ConvertToGuid(subItem.GetType().Name, subItem, enableZeroRemoving)));
            }
            else
            {
                values.AddRange(((IEnumerable)property.GetValue(item)).Cast<dynamic>());
            }

            return values;
        }

        private static dynamic? GetValue(object item, PropertyInfo property)
        {
            var value = property.GetValue(item);

            if (!property.CanWrite || property.GetIndexParameters().Length != 0 || property.GetCustomAttribute<GuidableAttribute>() == null)
            {
                return value;
            }

            var enableZeroRemoving = property.GetCustomAttribute<GuidableAttribute>()?.EnableZeroRemoving ?? true;

            //Skip if values is null
            return value is null ? value : ConvertToGuid(property.PropertyType.Name, value, enableZeroRemoving);
        }

        private static dynamic? ConvertToGuid(string propertyTypeName, object value, bool enableZeroRemoving)
        {
            return propertyTypeName switch
            {
                "String" => ((string)value).ToGuidFromString(),
                "Int16" => ((short)value).ToGuid(enableZeroRemoving),
                "Int32" => ((int)value).ToGuid(enableZeroRemoving),
                "Int64" => ((long)value).ToGuid(enableZeroRemoving),
                "UInt16" => ((ushort)value).ToGuid(enableZeroRemoving),
                "UInt32" => ((uint)value).ToGuid(enableZeroRemoving),
                "UInt64" => ((ulong)value).ToGuid(enableZeroRemoving),
                "Double" => ((double)value).ToGuid(enableZeroRemoving),
                "Single" => ((float)value).ToGuid(enableZeroRemoving),
                _ => value
            };
        }

        private static bool IsList(PropertyInfo propertyInfo)
        {
            // Check if the property type implements IEnumerable (non-generic)
            if (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
            {
                return true;
            }

            // Check if the property type implements IEnumerable<T> (generic)
            var genericEnumerableInterface = propertyInfo.PropertyType
                .GetInterfaces()
                .FirstOrDefault(interfaceType =>
                    interfaceType.IsGenericType &&
                    interfaceType.GetGenericTypeDefinition() == typeof(IEnumerable<>));

            return genericEnumerableInterface != null;
        }
    }
}
