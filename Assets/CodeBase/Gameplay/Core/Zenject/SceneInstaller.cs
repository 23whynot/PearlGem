using CodeBase.Gameplay.Balls.Player;
using CodeBase.Gameplay.Controllers.LevelEnd;
using CodeBase.Gameplay.Controllers.Renderer;
using CodeBase.Gameplay.Core.ObjPool;
using CodeBase.Gameplay.Factory;
using CodeBase.Gameplay.Services.RendererMaterialService;
using CodeBase.Gameplay.Sphere;
using Zenject;

namespace CodeBase.Gameplay.Core.Zenject
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMaterialService();
            
            BindSphereFactory();
            
            BindHUDInputProvider();
            
            BindBallCountController();
            
            BindObjectPool();
            
            BindColorOfZoneProvider();
            
            BindSphereGenerator();
            
            BindLevelEndController();
        }

        private void BindLevelEndController() => 
            Container.Bind<ILevelEndController>().FromComponentInHierarchy().AsSingle();

        private void BindSphereGenerator() => 
            Container.Bind<SphereGenerator>().FromComponentInHierarchy().AsSingle();

        private void BindColorOfZoneProvider() => 
            Container.Bind<IColorOfZoneProvider>().FromComponentInHierarchy().AsSingle();

        private void BindObjectPool() => 
            Container.Bind<ObjectPool>().AsSingle();

        private void BindBallCountController() => 
            Container.BindInterfacesAndSelfTo<BallCountController>().AsSingle();

        private void BindHUDInputProvider() => 
            Container.BindInterfacesAndSelfTo<HudInputProvider>().AsSingle();

        private void BindSphereFactory() => 
            Container.Bind<IBallFactory>().To<BallFactory>().AsSingle();

        private void BindMaterialService() => 
            Container.Bind<IMaterialService>().To<MaterialService>().AsSingle();
    }
}

