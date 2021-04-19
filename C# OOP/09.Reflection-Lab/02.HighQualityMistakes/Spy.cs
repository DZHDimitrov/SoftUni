using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);

            FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] methodsInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] methodsInfoPrivate = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in methodsInfo.Where(x=>x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            foreach (MethodInfo method in methodsInfoPrivate.Where(x=>x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
