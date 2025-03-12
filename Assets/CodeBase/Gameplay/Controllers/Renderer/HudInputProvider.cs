using System;

namespace CodeBase.Gameplay.Controllers.Renderer
{
    public class HudInputProvider : IHudInputProvider ,IChangeColorButtonListener
    {
        public event Action OnButtonClick;
        public void OnClick() => OnButtonClick?.Invoke();
    }
}