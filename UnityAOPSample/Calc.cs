using log4net;

namespace UnityAOPSample
{
    public class Calc
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public virtual int Add(int x, int y)
        {
            Log.Info("1. XXX");
            Log.Info("2. YYY");
            Log.Info("3. ZZZ");
            return Echo(x) + Echo(y);
        }

        public virtual int Mul(int x, int y)
        {
            Log.Info("1. AAA");
            Log.Info("2. BBB");
            Log.Info("3. CCC");
            return Echo(x) * Echo(y);
        }

        protected virtual int Echo(int x)
        {
            Log.Info("1. EchoEcho");
            Log.Info("2. ZZZZZZZZ");
            return x;
        }
    }
}