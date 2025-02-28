using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Gameplay.Factory
{
    public interface IBallFactory
    {
        public UniTask InitializeAsync();
        GameObject CreatePlayerBall(Transform at);
        UniTask<GameObject> GetSphereBall();
    }
}