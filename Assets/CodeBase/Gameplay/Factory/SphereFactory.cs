using CodeBase.Gameplay.Balls.Player;
using CodeBase.Gameplay.Core.ObjPool;
using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Factory
{
    public class SphereFactory : ISphereFactory
    {
        private readonly int _preLoadCount = 5;

        private ObjectPool _objectPool;
        private IAssetsProvider _assetsProvider;

        [Inject]
        public void Construct(ObjectPool objectPool, IAssetsProvider assetsProvider)
        {
            _objectPool = objectPool;
            _assetsProvider = assetsProvider;
        }

        public void Init()
        {
            InitAssetsProvider();
            RegisterInPool();
        }

        public GameObject CreatePlayerBall(Transform at)
        {

            return null;
        }

        private GameObject GetFromPool(object playerBall, Vector3 atPosition)
        {
            PlayerBall obj = _objectPool.GetObject<PlayerBall>();
            obj.transform.position = atPosition;
            obj.Activate();
            return obj.gameObject;
        }

        private void InitAssetsProvider()
        {
            
        }

        private void RegisterInPool()
        {
         //   _objectPool.RegisterPrefab<PlayerBall>(_assetsProvider.GetPrefab(AssetsProviderPath.Ball), _preLoadCount);
        }
    }
}