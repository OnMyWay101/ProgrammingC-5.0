using System;
using System.Runtime.CompilerServices;

namespace Ch15_Attributes
{
    class Compiler_Handled
    {
        public static void Example_CallerInfo()
        {
            Log("Begin My C# Study!");
        }

        public static void Log(
            string message,
            [CallerMemberName] string callingMethod = "",
            [CallerFilePathAttribute] string callingFile = "",
            [CallerLineNumber] int callingLineNumber = 0)
        {
            Console.WriteLine("Message {0}, called from {1} in file '{2}', line {3}",
                message, callingMethod, callingFile, callingLineNumber);
        }
    }
}
