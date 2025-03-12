using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.UI.LoadingCurtain.Proxy;
using CodeBase.Services.Log;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameBootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IAssetsProvider _assetsProvider;
        private readonly ILoadingCurtainProxy _loadingCurtainProxy;
        private readonly ILogService _logService;

        public GameBootstrapState(GameStateMachine gameStateMachine, 
            IAssetsProvider assetsProvider,
            ILoadingCurtainProxy loadingCurtainProxy,
            ILogService logService)
        {
            _gameStateMachine = gameStateMachine;
            _assetsProvider = assetsProvider;
            _loadingCurtainProxy = loadingCurtainProxy;
            _logService = logService;
        }
        
        public async UniTask Enter()
        {
            _logService.Log("GameBootstrapState Enter");
            
            await InitServices();
            
            _gameStateMachine.Enter<GameHubState>().Forget();
        }

        private async UniTask InitServices()
        {
            // Инициализация сервисов
            await _assetsProvider.InitializeAsync();
            await _loadingCurtainProxy.InitializeAsync();
        }

        public UniTask Exit() => default;
    }
}