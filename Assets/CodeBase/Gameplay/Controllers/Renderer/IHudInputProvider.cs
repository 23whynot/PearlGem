using System;

namespace CodeBase.Gameplay.Controllers.Renderer
{
    public interface IHudInputProvider
    {
        event Action OnButtonClick;
    }
}