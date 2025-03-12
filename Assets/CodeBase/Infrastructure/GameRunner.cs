using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
       private GameBootstrapper.Factory _gameBootstrapperFactory;

        [Inject] 
        public void Construct(GameBootstrapper.Factory bootstrapperFactory) => 
            _gameBootstrapperFactory = bootstrapperFactory;

        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameBootstrapper>();
            if (bootstrapper != null)
            {
                return;
            }

           GameBootstrapper obj = _gameBootstrapperFactory.Create();
           obj.transform.SetParent(null);
        }
    }
}