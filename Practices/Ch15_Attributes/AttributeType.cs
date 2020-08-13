using System;

namespace Ch15_Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginInformationAttribute : Attribute
    {
        public PluginInformationAttribute(string name, string auther)
        {
            Name = name;
            Auther = auther;
        }
        public string Name { get; private set; }
        public string Auther { get; private set; }
        public string Description { get; set; }
    }

    [PluginInformation("Reporting", "Interact Software Ltd.", Description = "Automated report generation")]
    public class ReportingPlugin
    {
        public static void Example_ShowAttribute()
        {
            ReportingPlugin rp = new ReportingPlugin();
            Type t = rp.GetType();
            var attrs = t.GetCustomAttributes(false);
            foreach(var attr in attrs)
            {
                Console.WriteLine("Name:{0}", ((PluginInformationAttribute)attr).Name);
                Console.WriteLine("Auther:{0}", ((PluginInformationAttribute)attr).Auther);
                Console.WriteLine("Description:{0}", ((PluginInformationAttribute)attr).Description);
            }
        }
    }
}
