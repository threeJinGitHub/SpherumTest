using TestMillionParticles.Components;
using UnityEngine;

namespace TestMillionParticles.Container
{
    public class SquareInitData : MonoBehaviour
    {
        [SerializeField] private Vector3 position;
        [SerializeField] private InputType inputType;
        [SerializeField, Range(0, 99f)] private float speed;
        [SerializeField] private Transform rayParticle;

        public Transform RayParticle => rayParticle;
        public Vector3 Position => position;
        public InputType InputType => inputType;
        public float Speed => speed;
    }    
}
