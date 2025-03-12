using CodeBase.Services.Log;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.SceneMenegment
{
    public class SceneLoader : ISceneLoader
    {
        private ILogService _log;

        public SceneLoader(ILogService log) => _log = log;

        public async UniTask Load(string sceneName)
        {
            AsyncOperationHandle<SceneInstance> handler = Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Single, false);

            await handler.ToUniTask();
            await handler.Result.ActivateAsync().ToUniTask();
            
            _log.Log($"Loaded scene '{sceneName}'.");
        }
    }
}