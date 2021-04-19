using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, string[] fields)
        {

            Type currentType = Type.GetType(className);

            FieldInfo[] infoaboutfields = currentType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(currentType, new object[] { });

            sb.AppendLine($"Class under investigation: {currentType}");

            foreach (var item in infoaboutfields.Where(x => fields.Contains(x.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();

        }
        public string RevealPrivateMethods(string className)
        {
            Type myType = Type.GetType(className);

            MethodInfo[] privateMethods = myType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"All Private Methods of Class: {className}")
                .AppendLine($"Base Class: {myType.BaseType.Name}");
            foreach (MethodInfo method in privateMethods)
            {
                sb.AppendLine($"{method.Name}");
            }
            return sb.ToString().TrimEnd();
        }
        public string CollectGettersAndSetters(string className)
        {
            Type myType = Type.GetType(className);

            MethodInfo[] methods = myType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            foreach (MethodInfo method in methods.Where(x=>x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (MethodInfo method in methods.Where(x=>x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return sb.ToString();
        }
    }
}
