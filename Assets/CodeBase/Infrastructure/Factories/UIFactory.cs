using CodeBase.Infrastructure.UI.HUD;

namespace CodeBase.Infrastructure.Factories
{
    public class UIFactory : IGameFactory
    {
        private readonly HUDRoot.Factory _hudRootFactory;

        public UIFactory(HUDRoot.Factory hudFactory)
        {
            _hudRootFactory = hudFactory;
        }
        
        
        public IHUDRoot CreateHUD() => _hudRootFactory.Create();
    }
}