using Commands;
using Data;
using Model;
using Storage;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameInstaller", menuName = "Installers/GameInstaller")]
public class GameInstaller : ScriptableObjectInstaller<GameInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IStorage>().WithId(StorageType.Local).To<LocalStorage>().AsSingle();
        Container.Bind<IStorage>().WithId(StorageType.Remote).To<RemoteStorage>().AsSingle();

        Container.Bind<User>().AsSingle();
        Container.Bind<UserData>().AsTransient();

        Container.Bind<GameConfig>().AsSingle();
        Container.Bind<GameData>().AsTransient();

        //Inject loaders for models
        Container.BindFactory<ILoadDataCommand, LoadDataFactory>().To<LoadLocalDataCommand>().WhenInjectedInto<User>();
        Container.BindFactory<ILoadDataCommand, LoadDataFactory>().To<LoadRemoteDataCommand>().WhenInjectedInto<GameConfig>();
    }
}