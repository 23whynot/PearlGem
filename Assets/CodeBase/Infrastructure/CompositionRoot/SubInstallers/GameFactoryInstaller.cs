using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.UI.HUD;
using Zenject;

namespace CodeBase.Infrastructure.CompositionRoot.SubInstallers
{
    public class GameFactoryInstaller : Installer<GameFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<HUDRoot, HUDRoot.Factory>().FromComponentInNewPrefabResource(InfrastructureAssetPath.HUDRoot);
            
            Container.Bind<IGameFactory>().To<UIFactory>().AsSingle();
        }
    }
}