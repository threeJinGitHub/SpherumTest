using Leopotam.Ecs;
using TestMillionParticles.Components;
using TestMillionParticles.Container;
using UnityEngine;

namespace TestMillionParticles.Systems
{
    public class ParticleMoveSystem : IEcsRunSystem
    {
        private EcsFilter<ParticleMoveData> _filter;
        private GameConfig _cfg;
        private const float MaxSpeed = 5;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var direction = ref _filter.Get1(i).PreviousDirection;
                ref var transform = ref _filter.Get1(i).PsTransform;
                
                var speed = Random.Range(0, MaxSpeed);
                
                direction = transform.position.magnitude > _cfg.psShellRadius
                    ? (direction - transform.position.normalized) / 2f
                    : (direction + Random.insideUnitSphere * Time.deltaTime).normalized;
                
                transform.Translate(direction * Time.deltaTime * speed);
            }
        }
    }
}