using EservicesDomain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;


namespace EServicesApplication.Helpers
{
    public static class TypeExtensions
    {
        public static bool IsComplex(this Type type)
        {
            // !type.IsValueType && type != typeof(string) && type != typeof(IFormFile) &&
            return (type.BaseType == typeof(IEntity<>)   || type.BaseType == typeof(IKtaEntity<>) );
        }


        public static bool IsCustomComplex(this Type type)
        {
            var elementType = type.GetCustomElementType();
            return elementType != null && elementType.IsComplex();
        }

        public static bool IsFile(this Type type)
        {
            var elementType = type.GetCustomElementType();
            return elementType != null && elementType == typeof(IFormFile);
        }

        public static Type GetCustomElementType(this Type type, object value)
        {
            return value != null
                ? value.GetType().GetCustomElementType()
                : type.GetCustomElementType();
        }

        public static Type GetCustomElementType(this Type type)
        {
            return type.IsCollection()
                ? type.IsArray
                    ? type.GetElementType()
                    : type.GetGenericArguments()[0]
                : type;
        }


        public static bool IsCustomComplex(this Type type, object value)
        {
            return value != null
                ? value.GetType().IsCustomComplex()
                : type.IsCustomComplex();
        }


        public static bool IsCollection(this Type type)
        {
            var collectionTypeName = typeof(IEnumerable<>).Name;
            return (type.Name == collectionTypeName || type.GetInterface(typeof(IEnumerable<>).Name) != null ||
                    type.IsArray) && type != typeof(string);
        }

        public static bool HasDefaultConstructor(this Type type)
        {
            return type.IsValueType || type.GetConstructor(Type.EmptyTypes) != null;
        }

    }
}
