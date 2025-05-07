using System.IO;

using System.Text;

namespace ZL.CS.IO.CSV
{
    public static partial class CSVManager
    {
        public static bool TryLoad<TCSVConvertible>(string path, out TCSVConvertible[] datas)

            where TCSVConvertible : ICSVRecord, new()
        {
            if (File.Exists(path) == false)
            {
                datas = null;

                return false;
            }

            var lines = File.ReadAllLines(path);

            datas = new TCSVConvertible[lines.Length - 1];

            for (int i = 1; i < lines.Length; ++i)
            {
                TCSVConvertible data = new();

                data.FromCSVRecord(lines[i].Split(','));

                datas[i - 1] = data;
            }

            return true;
        }

        public static void Save<TCSVConvertible>(string path, TCSVConvertible[] datas)

            where TCSVConvertible : ICSVRecord, new()
        {
            StringBuilder stringBuilder = new();

            stringBuilder.Append(datas[0].GetHeader());

            stringBuilder.AppendLine();

            for (int i = 0; i < datas.Length; ++i)
            {
                stringBuilder.Append(datas[i].ToCSVRecord());

                stringBuilder.AppendLine();
            }

            File.WriteAllText(path, stringBuilder.ToString(), Encoding.UTF8);
        }
    }
}