using UnityEngine;

using ZL.CS.IO.CSV;

namespace ZL.Unity.IO.CSV
{
    public abstract class ScriptableCSV : ScriptableObject, ICSVConvertible
    {
        public abstract void FromCSV(string[] values);

        public abstract string ToCSV();

        public abstract string GetHeaders();
    }
}