using System;

namespace CodeBase.Infrastructure.Services.Input
{
    public interface IInputService
    {
        bool IsHolding();
        
        event Action OnRelease;  
        float GetHorizontal();
        float GetVertical();
    }
}