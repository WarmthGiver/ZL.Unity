namespace ZL.CS.IO.CSV
{
    public interface ICSVConvertible
    {
        public abstract void FromCSV(string[] datas);

        public abstract string ToCSV();

        public abstract string GetCSVHeader();
    }
}