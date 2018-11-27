using Dapper;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DapperMapColumn
{
    public static class DapperMapper
    {
        public static void Mapper<T>()
        {
            var map = new CustomPropertyTypeMap(typeof(T),
                        (type, columnName) => type.GetProperties().FirstOrDefault(prop => GetDescriptionFromAttribute(prop).ToLower() == columnName.ToLower()));
            SqlMapper.SetTypeMap(typeof(T), map);
        }

        public static string GetDescriptionFromAttribute(MemberInfo member)
        {
            if (member == null) return null;
            var attrib = (DescriptionAttribute)Attribute.GetCustomAttribute(member, typeof(DescriptionAttribute), false);
            return attrib == null ? member.Name : attrib.Description;
        }
    }
}