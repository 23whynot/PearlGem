using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.UI.LoadingCurtain.Proxy
{
    public class LoadingCurtainProxy : ILoadingCurtain, ILoadingCurtainProxy
    {
        private LoadingCurtain.Factory _factory;
        private ILoadingCurtain _loadingCurtain;

        public LoadingCurtainProxy(LoadingCurtain.Factory factory) => 
            _factory = factory;

        public async UniTask InitializeAsync() => 
            _loadingCurtain = await _factory.Create(InfrastructureAssetPath.CurtainPath);

        public void Show() => 
            _loadingCurtain.Show();

        public void Hide() => 
            _loadingCurtain.Hide();
    }
}