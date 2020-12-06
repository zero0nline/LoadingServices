using Data;

namespace Model
{
    public interface IPersistent<out T> where T : LoadData
    {
        T Model { get; }
    }
}