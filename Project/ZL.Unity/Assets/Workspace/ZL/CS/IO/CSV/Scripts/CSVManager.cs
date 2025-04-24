using System.Collections.Generic;

using System.IO;

using System.Text;

namespace ZL.CS.IO
{
    public static partial class CSVManager
    {
        public static bool TryLoad<TCSVConvertible>(string filePath, out List<TCSVConvertible> datas)

            where TCSVConvertible : ICSVConvertible, new()
        {
            if (File.Exists(filePath) == false)
            {
                datas = null;

                return false;
            }

            var lines = File.ReadAllLines(filePath);

            datas = new(lines.Length - 1);

            for (int i = 1; i < lines.Length; ++i)
            {
                TCSVConvertible data = new();

                data.FromCSV(lines[i].Split(','));

                datas.Add(data);
            }

            return true;
        }

        public static void Save<TCSVConvertible>(string filePath, List<TCSVConvertible> datas)

            where TCSVConvertible : ICSVConvertible, new()
        {
            StringBuilder stringBuilder = new();

            stringBuilder.Append(datas[0].GetCSVHeader());

            stringBuilder.AppendLine();

            for (int i = 0; i < datas.Count; ++i)
            {
                stringBuilder.Append(datas[i].ToCSV());

                stringBuilder.AppendLine();
            }

            File.WriteAllText(filePath, stringBuilder.ToString(), Encoding.UTF8);
        }
    }
}