using UnityEngine;

namespace CodeBase.Gameplay.Services.RendererMaterialService
{
    public interface IMaterialService
    {
        void Init(Material material, int layersCount);
        Material GetMaterial(Color color);
        Material GetActualMaterial();
        void DeleteMaterial(Color color);
    }
}