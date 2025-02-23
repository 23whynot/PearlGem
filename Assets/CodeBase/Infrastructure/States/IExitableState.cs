using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure
{
    public interface IExitableState
    {
        UniTask Exit();
    }
}