using System;

namespace CodeBase.Gameplay.Balls.Player
{
    public interface IBallCountController
    {
        event Action<int> OnBallCountChanged;
        event Action OnBallsEnd;
        void OnShoot();
        void InitBallCount(int bonusBallCount);
        int GetBallCount();
    }
}