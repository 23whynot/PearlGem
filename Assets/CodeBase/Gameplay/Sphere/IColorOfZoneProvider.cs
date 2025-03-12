using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay.Sphere
{
    public interface IColorOfZoneProvider
    {
        public List<Color> GetColorsOfZone();

        public int GetCountZone();
        public int GetCountActiveZone();
        
        
    }
}