namespace ZL.CS.IO.CSV
{
    public interface ICSVConvertible
    {
        public abstract void FromCSV(string[] values);

        public abstract string ToCSV();

        public abstract string GetHeaders();
    }
}