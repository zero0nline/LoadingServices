using Model;
using Storage;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "LoadersInstaller", menuName = "Installers/LoadersInstaller")]
public class LoadersInstaller : ScriptableObjectInstaller<LoadersInstaller>
{
    public override void InstallBindings()
    {
        //Inject loaders for models
        Container.Bind<IStorage>().To<LocalStorage>().WhenInjectedInto<User>();
        Container.Bind<IStorage>().To<RemoteStorage>().WhenInjectedInto<GameConfig>();
    }
}