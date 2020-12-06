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
        
        Container.Bind<IStorage>().To<LocalJSONStorage>().AsSingle();

        Container.Bind<User>().AsSingle();
        Container.Bind<UserData>().AsTransient();
        
        Container.Bind<GameConfig>().AsSingle();
        Container.Bind<GameData>().AsTransient();
        
        Container.BindFactory<LoadDataCommand, LoadDataCommand.Factory>();
    }
}