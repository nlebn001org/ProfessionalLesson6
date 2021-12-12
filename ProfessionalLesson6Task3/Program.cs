using System;
using System.Linq;
using System.IO;
using System.Reflection;

namespace ProfessionalLesson6Task3
{   
    // Задание переделал под себя, чтобы лучше понять тему рефлексии. 
    class Program
    {
        static Assembly assembly = null;
        static string assemblyPath = @"C:\Users\user\Desktop\ITVDN_C#\C#Live\C#ProfessionalProjects\ProfessionalLesson6\Library\bin\Debug\net5.0\Library.dll";

        static void Main(string[] args)
        {
            try
            {
                assembly = Assembly.LoadFrom(assemblyPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Type t = assembly.GetType("Library.Customer");
            object[] constPar = { "Sean", 15 };
            object inst = Activator.CreateInstance(t, constPar); 
            MethodInfo method = t.GetMethod("Steal", BindingFlags.NonPublic | BindingFlags.Instance);

            object[] methPar = { 10 };
            method.Invoke(inst, methPar);
        }

        static void ShowAssemblyMembersIfno(string assemblyPath)
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFrom(assemblyPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Type[] types = assembly.GetTypes();
            foreach (var item in types)
            {
                Console.WriteLine("Loaded Assembly is: " + item.FullName);
                Console.WriteLine(new string('-', 20));
                MemberInfo[] members = item.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                foreach (var member in members)
                {
                    if (member.MemberType == MemberTypes.Method)
                        Console.WriteLine($"MemberType: {member.MemberType} || IsPrivate: {((MethodInfo)member).IsPrivate}  || Name: {member.Name}");
                    else
                        Console.WriteLine($"MemberType: {member.MemberType} || Name: {member.Name}");
                }
            }
        }

    }
}
