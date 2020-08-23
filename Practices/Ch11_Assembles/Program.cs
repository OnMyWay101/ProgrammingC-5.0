using System;

namespace System
{
    class String
    {
    }

}

class Program
{
    static void Main(string[] agrs)
    {
        System.String s1 = null;
        ShowStaticTypeNameAndAssembly(s1);
        String s2 = null;
        ShowStaticTypeNameAndAssembly(s2);
        ShowStaticTypeNameAndAssembly("String literal");
        ShowStaticTypeNameAndAssembly(Environment.OSVersion.VersionString);
        Console.ReadLine();
    }

    static void ShowStaticTypeNameAndAssembly<T>(T value)
    {
        Type t = typeof(T);
        Console.WriteLine("Type:{0},Assembly:{1}", t.FullName, t.Assembly.FullName);
    }
}
