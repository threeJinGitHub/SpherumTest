using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestMillionParticles.Utils
{
    public class UVsFixer : MonoBehaviour
    {
        [SerializeField] private List<MeshFilter> meshes;

        private void Awake()
        {
            for (int i = 0; i < meshes.Count; ++i)
            {
                var uvs = meshes[i].mesh.uv;
                var offset = new Vector2(200f * (i % 4) / 1024, 200f * (i / 4) / 1024);
                for (var j = 0; j < uvs.Length; ++j)
                {
                    uvs[j] /= 1024 / 200f;
                    uvs[j] += offset;
                }

                meshes[i].mesh.SetUVs(0, uvs);
            }
        }
    }    
}
