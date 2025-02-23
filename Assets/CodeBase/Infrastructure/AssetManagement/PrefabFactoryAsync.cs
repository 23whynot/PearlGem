using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.AssetManagement
{
    public class PrefabFactoryAsync<TComponent> : IFactory<string, UniTask<TComponent>>
    {
        private IInstantiator instantiator;
        private IAssetsProvider assetProvider;

        public PrefabFactoryAsync(IInstantiator instantiator, IAssetsProvider assetProvider)
        {
            this.instantiator = instantiator;
            this.assetProvider = assetProvider;
        }

        public async UniTask<TComponent> Create(string assetKey)
        {
            GameObject prefab = await assetProvider.Load<GameObject>(assetKey);
            GameObject newObject = instantiator.InstantiatePrefab(prefab);
            return newObject.GetComponent<TComponent>();
        }
    }
}