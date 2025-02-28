using CodeBase.Gameplay.Balls.Player;
using CodeBase.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using ObjectPool = CodeBase.Gameplay.Core.ObjPool.ObjectPool;

namespace CodeBase.Gameplay.Factory
{
    public class BallFactory : IBallFactory
    {
        private readonly int _preLoadCount = 5;

        private ObjectPool _objectPool;
        private IAssetsProvider _assetsProvider;
        private GameObject _playerBallPrefab;

        [Inject]
        public void Construct(ObjectPool objectPool, 
            IAssetsProvider assetsProvider)
        {
            _objectPool = objectPool;
            _assetsProvider = assetsProvider;
        }

        public async UniTask InitializeAsync()
        {
            await LoadPlayerBallAsync();
            RegisterInPool();
        }

        public async UniTask<GameObject> GetSphereBall() =>
            await _assetsProvider.Load<GameObject>(AssetsPath.SphereBall);

        public GameObject CreatePlayerBall(Transform at) =>
            GetFromPoolPlayerBall(at.position);

        private GameObject GetFromPoolPlayerBall(Vector3 atPosition)
        {
            PlayerBall obj = _objectPool.GetObject<PlayerBall>();
            obj.transform.position = atPosition;
            obj.Activate();
            return obj.gameObject;
        }

        private async UniTask LoadPlayerBallAsync() =>
            _playerBallPrefab = await _assetsProvider.Load<GameObject>(AssetsPath.PlayerBall);

        private void RegisterInPool() =>
            _objectPool.RegisterPrefab<PlayerBall>(_playerBallPrefab, _preLoadCount);
    }
}