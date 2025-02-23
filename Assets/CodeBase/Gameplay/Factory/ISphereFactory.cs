using UnityEngine;

namespace CodeBase.Gameplay.Factory
{
    public interface ISphereFactory
    {
        public void Init();
        GameObject CreatePlayerBall(Transform at);
    }
}