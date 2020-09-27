using System;
using System.Resources;

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
        //Example_Name();
        Example_Resource();
        Console.ReadLine();
    }


    static void Example_Name()
    {
        System.String s1 = null;
        ShowStaticTypeNameAndAssembly(s1);
        String s2 = null;
        ShowStaticTypeNameAndAssembly(s2);
        ShowStaticTypeNameAndAssembly("String literal");
        ShowStaticTypeNameAndAssembly(Environment.OSVersion.VersionString);
    }

    static void ShowStaticTypeNameAndAssembly<T>(T value)
    {
        Type t = typeof(T);
        Console.WriteLine("Type:{0},Assembly:{1}", t.FullName, t.Assembly.FullName);
    }

    static void Example_Resource()
    {
        var resource = new ResourceManager("Ch11_Assembles.MyResource", typeof(Program).Assembly);
        string colText = resource.GetString("ColString");

        Console.WriteLine("Add the color string:" + colText);
    }
}
