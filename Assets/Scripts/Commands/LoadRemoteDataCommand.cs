using Storage;
using Zenject;

namespace Commands
{
    public class LoadRemoteDataCommand : AbstractLoadDataCommand
    {
        public LoadRemoteDataCommand([Inject(Id = StorageType.Remote)] IStorage storage) : base(storage)
        {
        }
    }
}