using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace UnityAOPSample
{
    /// <summary>
    /// virtualなメソッドの前後にログ出力処理を埋め込むハンドラ
    /// </summary>
    public class LogBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Enumerable.Empty<Type>();
        }

        /// <summary>
        /// virtualなメソッドの呼び出しをラップする
        /// </summary>
        /// <param name="input"></param>
        /// <param name="getNext"></param>
        /// <returns></returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine($"# before: {input.MethodBase.Name}({string.Join(", ", input.Arguments.Cast<object>())})");
            
            // この行でvirtualなメソッドが呼び出され、戻り値が返却される
            var result = getNext()(input, getNext);

            Console.WriteLine($"# end: {input.MethodBase.Name}, result: {result.ReturnValue}");

            return result;
        }

        /// <summary>
        /// このBehaviorを割り込ませるかどうか
        /// falseにするとvirtualなメソッドのみ実行され、Aspectは実行されない
        /// </summary>
        public bool WillExecute => true;
    }
}