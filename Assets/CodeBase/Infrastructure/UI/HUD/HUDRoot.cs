using CodeBase.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.UI.HUD
{
    public class HUDRoot : MonoBehaviour, IHUDRoot
    {
        
        public class Factory : PlaceholderFactory<HUDRoot>
        {
            
        }
    }
}