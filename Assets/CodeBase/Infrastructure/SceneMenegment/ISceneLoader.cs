using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.SceneMenegment
{
    public interface ISceneLoader
    {
        UniTask Load(string sceneName);
    }
}