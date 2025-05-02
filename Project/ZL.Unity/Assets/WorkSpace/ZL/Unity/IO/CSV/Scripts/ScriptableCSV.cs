using UnityEngine;

using ZL.CS.IO;

namespace ZL.Unity.IO.CSV
{
    public abstract class ScriptableCSV : ScriptableObject, ICSVConvertible
    {
        public abstract void FromCSV(string[] lines);

        public abstract string ToCSV();

        public abstract string GetHeaders();
    }
}