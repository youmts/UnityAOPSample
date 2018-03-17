using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.TypeInterceptors.VirtualMethodInterception;

namespace UnityAOPSample
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            Log.Info("Main start");

            using (var container = new UnityContainer())
            {
                container.AddNewExtension<Interception>();
                container.RegisterType<Calc>(
                    new Interceptor<VirtualMethodInterceptor>(), // Calcのvirtualなメソッドにインターセプターを追加して生成
                    new InterceptionBehavior<LogBehavior>() // インターセプターはLogBehaviorとする
                    );

                var calc = container.Resolve<Calc>();
                var x = 10;
                var y = 2;

                Console.WriteLine();

                Console.WriteLine($"{x} + {y} = {calc.Add(x, y)}");
                Console.WriteLine();

                Console.WriteLine($"{x} * {y} = {calc.Mul(x, y)}");
                Console.WriteLine();
            }

            Console.WriteLine("Please press enter key.");
            Console.ReadLine();

            Log.Info("Main end");
        }
    }
}
