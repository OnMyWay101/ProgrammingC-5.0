using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch6_Inheritance
{
    class MyVirtual
    {
        public class BaseWithVirtual
        {
            public virtual void ShowMessage()
            {
                Console.WriteLine("Hello from BaseWithVirtual");
            }
        }
        public static void CallVirtualMethod(BaseWithVirtual bsv)
        {
            bsv.ShowMessage();
        }
        public class DeriveWithoutOverride:BaseWithVirtual
        {

        }
        public class DeriveAndOverride : BaseWithVirtual
        {
            public override void ShowMessage()
            {
                Console.WriteLine("This is an override");
            }
        }
        public static void Example_CallVirtualMethod()
        {
            CallVirtualMethod(new BaseWithVirtual());
            CallVirtualMethod(new DeriveWithoutOverride());
            CallVirtualMethod(new DeriveAndOverride());
        }

    }
}
