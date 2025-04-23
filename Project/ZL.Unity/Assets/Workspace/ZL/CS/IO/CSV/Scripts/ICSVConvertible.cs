namespace ZL.IO
{
    public interface ICSVConvertible
    {
        public abstract void FromCSV(string[] datas);

        public abstract string ToCSV();

        public abstract string GetCSVHeader();
    }
}