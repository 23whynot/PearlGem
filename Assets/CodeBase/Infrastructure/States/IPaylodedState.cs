using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure
{
    public interface IPaylodedState<TPayload> : IExitableState
    {
        UniTask Enter(TPayload payload);
    }
}