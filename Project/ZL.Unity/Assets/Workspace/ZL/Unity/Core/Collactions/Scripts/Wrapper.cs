using System;

namespace ZL.Collections
{
    [Serializable]

    public sealed class Wrapper<TValue>
    {
        public TValue value;
    }
}