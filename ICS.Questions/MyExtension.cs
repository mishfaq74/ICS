using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Questions
{
    public static class MyExtension
    {
        public static T? ConvertToEnum<T>(this string value) where T:struct
        {
            if(!Enum.IsDefined(typeof(T),value))
                return null;
            return (T)Enum.Parse(typeof(T), value,true);
        }
    }
}
