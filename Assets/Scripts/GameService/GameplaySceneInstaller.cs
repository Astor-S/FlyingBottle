using Zenject;
using GameService.ComboCounterService;
using GameService.GameHandlerSystem;
using GameService.ReviveService;
using PlayerControlSystem.LoaderService;

namespace GameService
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerLoader>().FromComponentInHierarchy().AsSingle();
            Container.Bind<GameHandler>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerTracker>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ComboCounter>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Reviver>().FromComponentInHierarchy().AsSingle();
        }
    }
}