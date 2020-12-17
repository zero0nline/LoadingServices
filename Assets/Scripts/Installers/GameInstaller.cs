using Data;
using Model;
using UI.Presenters;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameInstaller", menuName = "Installers/GameInstaller")]
public class GameInstaller : ScriptableObjectInstaller<GameInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<Canvas>().FromComponentInHierarchy(false).AsSingle();
        
        Container.Bind<User>().AsSingle();
        Container.Bind<UserData>().AsSingle();

        Container.Bind<GameConfig>().AsSingle();
        Container.Bind<GameData>().AsSingle();

        Container.Bind<GameConfigPresenter>().AsTransient();
        Container.Bind<UserPresenter>().AsTransient();
    }
}