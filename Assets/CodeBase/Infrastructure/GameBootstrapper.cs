using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;


namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private StatesFactory _statesFactory;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine, StatesFactory statesFactory)
        {
            _gameStateMachine = gameStateMachine;
            _statesFactory = statesFactory;

        }

        private void Start()
        {
            _gameStateMachine.RegisterState(_statesFactory.Create<GameBootstrapState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<GameLoadingState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<GameHubState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<GameplayState>()); 
            
            _gameStateMachine.Enter<GameBootstrapState>();
                                                            
            
            DontDestroyOnLoad(gameObject);
        }

        public class Factory : PlaceholderFactory<GameBootstrapper>
        {
        }
     
    }
}
