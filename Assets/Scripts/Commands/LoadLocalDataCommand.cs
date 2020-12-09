using Storage;
using Zenject;

namespace Commands
{
    public class LoadLocalDataCommand : AbstractLoadDataCommand
    {
        public LoadLocalDataCommand([Inject(Id = StorageType.Local)] IStorage storage) : base(storage)
        {
        }
    }
}