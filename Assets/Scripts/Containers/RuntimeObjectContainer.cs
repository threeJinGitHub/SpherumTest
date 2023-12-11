using System.Collections.Generic;
using UnityEngine;

namespace TestMillionParticles.Container
{
    public class RuntimeObjectContainer : MonoBehaviour
    {
        [SerializeField] private List<GameObject> spheres;
        [SerializeField] private Transform cubesHolder;

        public List<GameObject> Spheres => spheres;
        public Transform CubesHolder => cubesHolder;
    }    
}
