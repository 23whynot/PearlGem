using CodeBase.Infrastructure.UI.HUD;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public interface IGameFactory
    {
        IHUDRoot CreateHUD();
    }
}