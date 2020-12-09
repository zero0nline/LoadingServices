namespace Data
{
    public abstract class LoadData
    {
        public abstract string KeyName { get; }
        public abstract LoadData GetDefaultValue();
    }
}