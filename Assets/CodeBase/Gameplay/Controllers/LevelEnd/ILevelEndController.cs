using System;

namespace CodeBase.Gameplay.Controllers.LevelEnd
{
    public interface ILevelEndController
    {
        public event Action OnLevelEnded;
    }
}