using GestorProyectos.Base.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GestorProyectos.Infrastructure.Extensions
{
    public static class ObjectExtension
    {
        public static string GetQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null && !p.GetCustomAttributes(true).Any(a => a.GetType() == typeof(IgnoreToQueryAttribute)) 
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }
    }
}
