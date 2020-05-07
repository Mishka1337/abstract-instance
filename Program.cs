using System;
using System.Reflection;

namespace DigDesHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Type abstractClassType = Type.GetType("DigDesHomework.SomeAbstractClass");

            var runtimeTypeHandleType = Type.GetType("System.RuntimeTypeHandle");

            var allocationMethod = runtimeTypeHandleType
                        .GetMethod("Allocate", BindingFlags.Static | BindingFlags.NonPublic);

            var allocationParameter = abstractClassType.UnderlyingSystemType;
            var allocationParameters = new object[] { allocationParameter};
            

            var instance = allocationMethod.Invoke(null, allocationParameters) as SomeAbstractClass;

            instance.Print();

        }
    }

    abstract class SomeAbstractClass
    {
        public void Print()
        {
            Console.WriteLine("Hello, DigDes!");
        }
    }

}
