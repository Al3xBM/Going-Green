using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FormGenerator.Entities;

namespace FormGenerator.Data
{
    public static class ProductList
    {
        public static List<Type> GetAllProductTypes()
        {
            return (
                      from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                      from assemblyType in domainAssembly.GetTypes()
                      where typeof(BaseProduct).IsAssignableFrom(assemblyType)
                      select assemblyType
                  ).ToList();
        }

        public static object CastPropertyValue(PropertyInfo property, string value)
        {
            if (property == null || String.IsNullOrEmpty(value))
                return null;
            if (property.PropertyType.IsEnum)
            {
                Type enumType = property.PropertyType;
                if (Enum.IsDefined(enumType, value))
                    return Enum.Parse(enumType, value);
            }
            if (property.PropertyType == typeof(bool))
                return value == "1" || value == "true" || value == "on" || value == "checked";
            else if (property.PropertyType == typeof(Uri))
                return new Uri(Convert.ToString(value));
            else
                return Convert.ChangeType(value, property.PropertyType);
        }

        public static List<string> GetAllProductNames()
        {
            return (
                  from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                  from assemblyType in domainAssembly.GetTypes()
                  where typeof(BaseProduct).IsAssignableFrom(assemblyType)
                  select assemblyType.Name
              ).ToList();
        }

        public static List<string> GetProductProperties(string applienceCategory)
        {
            var listOfProducts = ProductList.GetAllProductTypes();

            List<string> properties = new List<string>();

            foreach (var type in listOfProducts)
            {
                if (type.Name == applienceCategory)
                {
                    foreach (var prop in type.GetProperties())
                    {
                        properties.Add(prop.Name);
                    }
                    break;
                }
            }

            properties.Remove("ID");
            properties.Remove("Type");

            return properties;
        }
    }

}
