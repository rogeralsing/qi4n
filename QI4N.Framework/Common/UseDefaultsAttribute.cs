namespace QI4N.Framework
{
    using System;

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class UseDefaultsAttribute : InjectionAttribute
    {
    }
}