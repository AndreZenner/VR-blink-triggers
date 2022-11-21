using UnityEngine;

namespace BT
{
    public class ImageEffect: MonoBehaviour
    {
        private Material mat;
       

        void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (mat != null) Graphics.Blit(source, destination, mat);
            else Graphics.Blit(source, destination);
        }

        public void SetShaderMaterial(Material newMaterial)
        {
            mat = newMaterial;
        }
    }
}