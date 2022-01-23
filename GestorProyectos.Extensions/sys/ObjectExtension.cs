using GestorProyectos.Extensions.Entity;
using GestorProyectos.Extensions.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

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

        public static string GetQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }

        public async static Task<ApiResponse<T>> returnResponse<T>(this T myobj, Metadata metadata = null)
        {
            var response = new ApiResponse<T>(myobj, metadata);
            return response;
        }

        public static Expression<Func<T, bool>> AndAlso<T>( this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            // need to detect whether they use the same
            // parameter instance; if not, they need fixing
            ParameterExpression param = expr1.Parameters[0];
            if (ReferenceEquals(param, expr2.Parameters[0]))
            {
                // simple version
                return Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(expr1.Body, expr2.Body), param);
            }
            // otherwise, keep expr1 "as is" and invoke expr2
            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    expr1.Body,
                    Expression.Invoke(expr2, param)), param);
        }
    }
}
