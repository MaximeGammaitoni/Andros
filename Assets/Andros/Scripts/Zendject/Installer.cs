using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    public PrefabsLoaderManagerFactory PrefabsLoaderManagerFactory;
    public override void InstallBindings()
    {
        Container.Bind<StatesManager>().AsSingle();
        Container.Bind<GameManager>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<PrefabsLoaderManager>().FromIFactory(x => x.To<PrefabsLoaderManagerFactory>().FromScriptableObject(PrefabsLoaderManagerFactory).AsSingle()).AsSingle();
    }
}
