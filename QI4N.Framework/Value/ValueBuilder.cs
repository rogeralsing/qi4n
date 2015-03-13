﻿namespace QI4N.Framework
{
    public interface ValueBuilder<T>
    {
        T NewInstance();

        K PrototypeFor<K>();

        T Prototype();

        void Use(params object[] items);
    }
}