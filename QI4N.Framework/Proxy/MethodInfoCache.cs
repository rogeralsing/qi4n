namespace QI4N.Framework.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class MethodInfoCache
    {
        private static readonly IList<MethodInfo> methodLookup = new List<MethodInfo>();

        private static readonly object syncRoot = new object();

        //[DebuggerStepThrough]
        ////[DebuggerHidden]
        public static int AddMethod(MethodInfo methodInfo)
        {
            lock (syncRoot)
            {
                int methodId = methodLookup.Count;
                methodLookup.Add(methodInfo);

                return methodId;
            }
        }


        //[DebuggerStepThrough]
        ////[DebuggerHidden]

        public static MethodInfo GetGenericMethod(int methodId, Type[] genericArguments)
        {
            MethodInfo method = methodLookup[methodId];
            MethodInfo generic = method.MakeGenericMethod(genericArguments);

            return generic;
        }

        public static MethodInfo GetMethod(int methodId)
        {
            return methodLookup[methodId];
        }
    }
}