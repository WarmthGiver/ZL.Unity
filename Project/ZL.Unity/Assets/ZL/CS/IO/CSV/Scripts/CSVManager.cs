using System.Collections.Generic;

using System.IO;

using System.Text;

namespace ZL.CS.IO
{
    public static class CSVManager
    {
        public static bool TryLoad<T>(string filePath, out List<T> datas)

            where T : ICSVConvertible, new()
        {
            if (File.Exists(filePath) == false)
            {
                datas = null;

                return false;
            }

            string[] lines = File.ReadAllLines(filePath);

            datas = new(lines.Length - 1);

            for (int i = 1; i < lines.Length; ++i)
            {
                T data = new();

                data.FromCSV(lines[i].Split(','));

                datas.Add(data);
            }

            return true;
        }

        public static void Save<T>(string filePath, List<T> datas)

            where T : ICSVConvertible, new()
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

    public interface ICSVConvertible
    {
        public abstract void FromCSV(string[] datas);

        public abstract string ToCSV();

        public abstract string GetCSVHeader();       
    }
}