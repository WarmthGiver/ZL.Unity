using UnityEngine;

using ZL.CS.IO.CSV;

namespace ZL.Unity.IO.CSV
{
    public abstract class ScriptableCSVRecord : ScriptableObject, ICSVRecord
    {
        public abstract string GetHeader();

        public abstract void FromCSVRecord(string[] values);

        public abstract string ToCSVRecord();
    }
}