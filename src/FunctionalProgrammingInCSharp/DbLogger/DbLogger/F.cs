using System;

namespace DbLogger
{
    public static class F
    {
        public static TR Using<TDisp, TR>(TDisp disposable,
            Func<TDisp, TR> f) where TDisp : IDisposable
        {
            using (disposable) return f(disposable);
        }
    }
}
