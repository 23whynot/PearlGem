using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;
using Zenject;

namespace CodeBase.Infrastructure.CompositionRoot.SubInstallers
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StatesFactory>().AsSingle();
            
            Container.Bind<GameStateMachine>().AsSingle().NonLazy();
        }
    }
}