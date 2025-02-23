using System;
using UnityEngine;

namespace CodeBase.Gameplay.Zone
{
    public interface IColorZone
    {
        public event Action<ColorZone> OnZoneDestroyed; 
        public void DestroyAllBallsInZone();
        public Transform GetNonRotationalParent();
        public Color Color { get; }
    }
}