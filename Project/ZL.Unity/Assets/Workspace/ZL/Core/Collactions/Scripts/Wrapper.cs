using System;

namespace ZL.Unity
{
    [Serializable]

    public sealed class Wrapper<TValue>
    {
        public TValue value;
    }
}