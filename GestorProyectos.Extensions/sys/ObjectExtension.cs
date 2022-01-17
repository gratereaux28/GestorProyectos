﻿using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GestorProyectos.Extensions.sys
{
    public static class ObjectExtension
    {
        public static T Cast<T>(this Object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                var prop = myobj.GetType().GetProperty(memberInfo.Name);
                var currentType = memberInfo.GetType();

                if (prop != null)
                {
                    value = prop.GetValue(myobj, null);
                    propertyInfo.SetValue(x, value, null);
                }
            }
            return (T)x;
        }

        public static T CopyTo<T>(this Object myobj, T copyObj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = copyObj;
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                var prop = myobj.GetType().GetProperty(memberInfo.Name);
                if (prop != null)
                {
                    value = prop.GetValue(myobj, null);
                    if (value != null)
                    {
                        propertyInfo.SetValue(x, value, null);
                    }
                }
            }
            return (T)x;
        }

        //public static string[] UpdateColumnsName(this Type objectType, string[] columnsName)
        //{
        //    var z = objectType.GetMembers().ToList();

        //    for (int i = 0; i < columnsName.Length; i++)
        //    {
        //        var info = z.FirstOrDefault(m => m.Name.Replace("get_", "").ToLower() == columnsName[i].ToLower());
        //        if (info != null)
        //        {
        //            columnsName[i] = info.Name.Replace("get_", "");
        //        }
        //        else if (columnsName[i].Contains("."))
        //        {
        //            Type currentType = objectType;
        //            var spllitedName = columnsName[i].Split(".");
        //            List<string> newProp = new List<string>();
        //            for (int j = 0; j < spllitedName.Length; j++)
        //            {
        //                var item = spllitedName[j];
        //                info = z.FirstOrDefault(m => m.Name.Replace("get_", "").ToLower() == item.ToLower());
        //                if (info != null)
        //                {
        //                    newProp.Add(info.Name.Replace("get_", ""));
        //                    currentType = info.DeclaringType;
        //                }

        //            }
        //            columnsName[i] = newProp.Join(".");
        //        }
        //    }

        //    return columnsName;
        //}

        public static string GetValue(this Object myobj, string property)
        {
            PropertyInfo propertyInfo;
            object value = myobj;
            Type currentType = myobj.GetType();
            foreach (string field in property.Split('.'))
            {
                propertyInfo = currentType.GetProperty(field);
                var prop = value.GetType().GetProperty(propertyInfo.Name);
                value = prop.GetValue(myobj, null);
                currentType = currentType.GetType();
            }
            return value?.ToString();
        }


        public static string ToJson(this Object obj)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(obj, serializerSettings);
        }
    }
}
