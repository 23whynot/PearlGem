using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.SceneMenegment;
using CodeBase.Infrastructure.UI.LoadingCurtain;
using CodeBase.Services.Log;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameplayState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILogService _logService;
        private readonly IAssetsProvider _assetsProvider;

        public GameplayState(ILoadingCurtain loadingCurtain,
            ISceneLoader sceneLoader,
            ILogService logService,
            IAssetsProvider assetsProvider)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _logService = logService;
            _assetsProvider = assetsProvider;
        }

        public async UniTask Enter()
        {
            _logService.Log("GamePlayState Enter");
            _loadingCurtain.Show();

            await _assetsProvider.WarmupAssetsByLabel(AssetsLabels.GameplayState);
            await _sceneLoader.Load(InfrastructureAssetPath.GameMode1Scene);
            
            _loadingCurtain.Hide();
        }

        public async UniTask Exit()
        {
            _loadingCurtain.Show();
         //   await _assetsProvider.ReleaseAssetsByLabel(AssetsLabels.GameplayState);
        }
    }
}