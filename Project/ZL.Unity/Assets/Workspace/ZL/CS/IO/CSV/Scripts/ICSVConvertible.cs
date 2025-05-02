namespace ZL.CS.IO
{
    public interface ICSVConvertible
    {
        public abstract void FromCSV(string[] datas);

        public abstract string ToCSV();

        public abstract string GetHeaders();
    }
}