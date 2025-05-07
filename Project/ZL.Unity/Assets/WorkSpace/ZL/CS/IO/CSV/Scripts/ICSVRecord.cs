namespace ZL.CS.IO.CSV
{
    public interface ICSVRecord
    {
        public abstract string GetHeader();

        public abstract void FromCSVRecord(string[] values);

        public abstract string ToCSVRecord();
    }
}