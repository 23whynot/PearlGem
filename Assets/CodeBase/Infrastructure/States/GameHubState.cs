using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.SceneMenegment;
using CodeBase.Infrastructure.States;
using CodeBase.Infrastructure.UI.LoadingCurtain;
using CodeBase.Services.Log;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure
{
    public class GameHubState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILogService _log;

        public GameHubState(ILoadingCurtain loadingCurtain, 
            ISceneLoader sceneLoader, 
            ILogService log)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _log = log;
        }

        public async UniTask Enter()
        {
           _log.Log("GameHubState Enter");
           
           _loadingCurtain.Show();
           
           await _sceneLoader.Load(InfrastructureAssetPath.GameHubScene);
           
           _loadingCurtain.Hide();
        }

        public async UniTask Exit()
        {
            _loadingCurtain.Show();
        }
    }
}