using CodeBase.Infrastructure.SceneMenegment;
using CodeBase.Infrastructure.UI.LoadingCurtain;
using CodeBase.Services.Log;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameLoadingState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILogService _logService;

        public GameLoadingState(ILoadingCurtain loadingCurtain, 
            ISceneLoader sceneLoader, 
            ILogService logService)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _logService = logService;
        }
        
        public async UniTask Enter()
        {
            _logService.Log("GameLoadingState Enter");
            
            await _sceneLoader.Load(InfrastructureAssetPath.GameLoadingScene);
            
            _loadingCurtain.Show();
        }

        public async UniTask Exit() => _loadingCurtain.Hide();
    }
}